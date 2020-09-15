using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Follow : StateMachineBehaviour
{
	private bool rotated;
	private Vector3 startForward;
	[SerializeField] private float speed;
	[SerializeField] private float stopPlayerRange;
	[SerializeField] private float destinationRange;
	[SerializeField] private float stopDestinationRange;
	[SerializeField] private float angularSpeed;

	private float velocity;
	private float current;

	private Player player;
	private EnemyIntelligence enemyInt;
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		player = PlayerManager.Instance.Player.GetComponent<Player>();
		enemyInt = animator.GetComponent<EnemyIntelligence>();

		velocity = 0;
		current = 0;
		rotated = false;
		startForward = enemyInt.transform.forward;

		enemyInt.attackDir = new Vector3(1, 0, 0);

		animator.SetBool("playerInRange", false);
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		var playerPos = player.transform.position;
		var toPlayer = playerPos - enemyInt.transform.position;

		//var destination = playerPos + enemyInt.attackDir * destinationRange;
		var toDestination = toPlayer + enemyInt.attackDir * destinationRange;

		var target = -Vector2.SignedAngle(new Vector2(startForward.x, startForward.z), new Vector2(toDestination.x, toDestination.z));
		current = Mathf.SmoothDampAngle(current, target, ref velocity, 1 / angularSpeed);
		//current = target;
		enemyInt.transform.forward = Quaternion.Euler(0, current, 0) * startForward;

		if (Mathf.Abs(current - target) < 0.1)
			rotated = true;

		if (toPlayer.sqrMagnitude <= stopPlayerRange * stopPlayerRange
			|| toDestination.sqrMagnitude <= stopDestinationRange * stopDestinationRange)
			animator.SetBool("playerInRange", true);
		else if (rotated)
			enemyInt.transform.position += enemyInt.transform.forward * speed * Time.deltaTime;
	}
}
