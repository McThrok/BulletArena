using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class PrepareAttack : StateMachineBehaviour
{
	private Player player;
	private EnemyIntelligence enemyInt;
	private NavMeshAgent navMeshAgent;

	public float requiredAngleToPlayer = 15;
	public float maxDistOffset = 2;
	private float maxDist;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		player = PlayerManager.Instance.Player.GetComponent<Player>();
		enemyInt = animator.GetComponent<EnemyIntelligence>();
		navMeshAgent = animator.GetComponent<NavMeshAgent>();

		maxDist = (player.transform.position - animator.transform.position).magnitude + maxDistOffset;
		animator.GetComponent<NavMeshAgent>().SetDestination(animator.transform.position);
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		var playerPos = player.transform.position;
		var toPlayer = playerPos - animator.transform.position;

		if (toPlayer.sqrMagnitude > maxDist * maxDist)
			animator.SetBool("playerInRange", false);

		var fd = enemyInt.FollowDist + enemyInt.FollowMinOffset;
		var dest = playerPos + enemyInt.attackDir * fd;
		navMeshAgent.SetDestination(dest);

		var angle = Vector3.Angle(toPlayer, animator.transform.forward);

		if (toPlayer.sqrMagnitude <= 0.1 * 0.1)
		{
			animator.SetTrigger("readyToAttack");
		}
		else if (angle <= requiredAngleToPlayer)
		{
			var ray = new Ray(animator.transform.position, animator.transform.forward);
			if (player.GetComponent<Collider>().Raycast(ray, out _, 1000))
				animator.SetTrigger("readyToAttack");
		}
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.ResetTrigger("readyToAttack");
	}
}
