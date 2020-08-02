using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIntelligence : MonoBehaviour
{
	State state = State.Idle;
	Player player;
	float backTime = 1;
	float currentBackTime = 1;
	// Start is called before the first frame update
	void Start()
	{
		player = PlayerManager.Instance.Player.GetComponent<Player>();
	}

	// Update is called once per frame
	void Update()
	{
		if (state == State.Idle)
		{
			if (player != null)
				state = State.Follow;
		}
		else if (state == State.Follow)
		{
			var toPlayer = player.transform.position - transform.position;
			if (toPlayer.magnitude < 1f)
				state = State.Attack;
			else
			{
				transform.rotation = Quaternion.FromToRotation(Vector3.forward, toPlayer);
				GetComponent<Rigidbody>().velocity = transform.forward * 2;
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
				GetComponent<Rigidbody>().velocity = -0.5f * transform.forward;

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
