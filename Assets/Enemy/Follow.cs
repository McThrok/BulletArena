using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Follow : StateMachineBehaviour
{
	private bool rotated;
	private Vector3 startForward;
	private float current;
	private float velocity;

	private Player player;
	private EnemyIntelligence enemyInt;
	private NavMeshAgent navMeshAgent;
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		player = PlayerManager.Instance.Player.GetComponent<Player>();
		enemyInt = animator.GetComponent<EnemyIntelligence>();
		navMeshAgent = animator.GetComponent<NavMeshAgent>();

		navMeshAgent.updateRotation = false;
		current = 0;
		velocity = 0;
		rotated = false;
		startForward = navMeshAgent.transform.forward;

		animator.SetBool("playerInRange", false);
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		var playerPos = player.transform.position;
		var toPlayer = playerPos - animator.transform.position;

		var dist = enemyInt.FollowDist + enemyInt.FollowMinOffset;
		var dest = playerPos + enemyInt.attackDir * dist;
		var a = navMeshAgent.SetDestination(dest);
		var b = navMeshAgent.SetDestination(playerPos);

		if (!rotated)
		{
			var to = navMeshAgent.steeringTarget;// - navMeshAgent.transform.position;
			var target = Vector2.Angle(new Vector2(startForward.x,startForward.z), new Vector2(to.x, to.z));

			//current = Mathf.SmoothDampAngle(current, target, ref velocity, 0.2F);

			navMeshAgent.transform.forward = Quaternion.Euler(0, target, 0) * startForward;

			navMeshAgent.ResetPath();

			//if (Mathf.Abs(current - target) < 1e-5)
			//rotated = true;
		}
		else
		{
			var remaining = navMeshAgent.remainingDistance - navMeshAgent.stoppingDistance;
			if (toPlayer.sqrMagnitude <= dist * dist || remaining < 0.01)
				animator.SetBool("playerInRange", true);
			else
				navMeshAgent.transform.forward = toPlayer;
		}
	}
}
