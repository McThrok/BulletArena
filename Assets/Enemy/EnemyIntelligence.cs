using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIntelligence : MonoBehaviour
{
	public GameObject EnemyBody;
	private Transform enemyTr;
	private Player player;

	private State state = State.Idle;
	private float speed = 3.0f;

	private float backTime = 1;
	private float attackTime = 0.05f;
	private float currentTime = 0;
	private float attackDist = 0.5f;

	void Start()
	{
		player = PlayerManager.Instance.Player.GetComponent<Player>();
		enemyTr = EnemyBody.transform;
	}

	void Update()
	{
		switch (state)
		{
			case State.Idle: HandleIdle(); return;
			case State.Follow: HandleFollow(); return;
			case State.Attack: HandleAttack(); return;
			case State.Back: HandleBack(); return;
		}
	}
	private void HandleIdle()
	{
		if (player != null)
			state = State.Follow;
	}
	private void HandleFollow()
	{
		var toPlayer = player.transform.position - enemyTr.position;
		if (toPlayer.magnitude < 1f)
			state = State.Attack;
		else
		{
			enemyTr.rotation = Quaternion.FromToRotation(Vector3.forward, toPlayer);
			enemyTr.position += enemyTr.forward * Time.deltaTime * speed;
		}
	}
	private void HandleAttack()
	{
		enemyTr.position += (attackDist/attackTime) * enemyTr.forward * Time.deltaTime;

		currentTime += Time.deltaTime;
		if (currentTime >= attackTime)
		{
			currentTime = 0;
			player.Hit(10);
			state = State.Back;
		}
	}
	private void HandleBack()
	{
		enemyTr.position -= (attackDist / backTime) * enemyTr.forward * Time.deltaTime;

		currentTime += Time.deltaTime;
		if (currentTime >= backTime)
		{
			currentTime = 0;
			state = State.Idle;
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
