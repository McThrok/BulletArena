using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIntelligence : MonoBehaviour
{
	public GameObject EnemyBody;
	private Transform enemyTr;
	private Player player;
	private Animator animator;

	//private State state = State.Idle;
	//private float speed = 3.0f;
	public float rotationSpeed = 10.0f;

	private float backTime = 1;
	private float attackTime = 0.1f;
	private float currentTime = 0;
	private float attackDist = 2.3f;

	public float FollowDist = 10f;
	public float FollowMinOffset = -7;
	public float PrepareMaxOffset = 3.5f;

	Vector3 playerPos;
	[HideInInspector] public Vector3 attackDir;

	void Start()
	{
		if (PlayerManager.Instance.Player != null)
			player = PlayerManager.Instance.Player.GetComponent<Player>();
		//enemyTr = EnemyBody.transform;
		enemyTr = transform;
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		animator.SetBool("playerPresent", player != null);
		//if (player == null)
		//	state = State.Idle;
		//else
		//	playerPos = player.transform.position;

		//switch (state)
		//{
		//	case State.Idle: HandleIdle(); return;
		//	case State.Follow: HandleFollow(); return;
		//	case State.Attack: HandleAttack(); return;
		//	case State.Back: HandleBack(); return;
		//}
	}
	//private void HandleIdle()
	//{
	//	if (player != null)
	//		state = State.Follow;
	//}
	//private void HandleFollow()
	//{
	//	var toPlayer = playerPos - enemyTr.position;
	//	toPlayer.y = 0;
	//	//enemyTr.rotation = Quaternion.FromToRotation(Vector3.forward, toPlayer);


	//	if (toPlayer.magnitude < 2f)
	//		state = State.Attack;
	//	else
	//		GetComponent<NavMeshAgent>().SetDestination(playerPos);
	//	//GetComponent<NavMeshAgent>().
	//	//enemyTr.position += enemyTr.forward * Time.deltaTime * speed;
	//}
	//private void HandleAttack()
	//{
	//	var toPlayer = playerPos - enemyTr.position;
	//	toPlayer.y = 0;
	//	var dist = attackDist + toPlayer.magnitude;
	//	enemyTr.position += (dist / attackTime) * enemyTr.forward * Time.deltaTime;

	//	currentTime += Time.deltaTime;
	//	if (currentTime >= attackTime)
	//	{
	//		currentTime = 0;
	//		player.Hit(10);
	//		state = State.Back;
	//	}
	//}
	//private void HandleBack()
	//{
	//	enemyTr.position -= ((attackDist + 1) / backTime) * enemyTr.forward * Time.deltaTime;

	//	currentTime += Time.deltaTime;
	//	if (currentTime >= backTime)
	//	{
	//		currentTime = 0;
	//		state = State.Idle;
	//	}
	//}
}
//enum State
//{
//	Idle,
//	Follow,
//	Attack,
//	Back
//}
