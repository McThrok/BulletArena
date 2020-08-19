using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIntelligence : MonoBehaviour
{
	public GameObject EnemyBody;
	Transform tr;
	Rigidbody rb;

	State state = State.Idle;
	Player player;
	float backTime = 1;
	float currentBackTime = 1;
	void Start()
	{
		player = PlayerManager.Instance.Player.GetComponent<Player>();
		tr = EnemyBody.transform;
		rb = EnemyBody.GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (state == State.Idle)
		{
			if (player != null)
				state = State.Follow;
		}
		else if (state == State.Follow)
		{
			var toPlayer = player.transform.position - tr.position;
			if (toPlayer.magnitude < 1f)
				state = State.Attack;
			else
			{
				tr.rotation = Quaternion.FromToRotation(Vector3.forward, toPlayer);
				rb.velocity = tr.forward * 2;
			}
		}
		else if (state == State.Attack)
		{
			player.Hit(10);
			state = State.Back;
		}
		else if (state == State.Back)
		{
			if (currentBackTime == 0)
				rb.velocity = -0.5f * tr.forward;

			currentBackTime += Time.deltaTime;

			if (currentBackTime >= backTime)
			{
				currentBackTime = 0;
				state = State.Idle;
			}
		}
	}
}
enum State
{
	Idle,
	Follow,
	Attack,
	Back
}
