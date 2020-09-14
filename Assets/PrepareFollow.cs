using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PrepareFollow : StateMachineBehaviour
{
	private Player player;
	private Vector3 attackDir;
	private EnemyIntelligence enemyInt;
	private NavMeshAgent navMeshAgent;


	public float PrepareTime = 0.5f;
	Vector3 currentVelocity;
	private float currentTime;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		player = PlayerManager.Instance.Player.GetComponent<Player>();

		navMeshAgent = animator.GetComponent<NavMeshAgent>();
		navMeshAgent.isStopped = true;

		var randomDir = Random.insideUnitCircle;
		enemyInt.attackDir = new Vector3(randomDir.x, 0, randomDir.y);
		enemyInt.attackDir = new Vector3(1, 0, 0);

		currentTime = 0;
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		var dist = enemyInt.FollowDist + enemyInt.FollowMinOffset;
		var dest = player.transform.position + enemyInt.attackDir * dist;
		navMeshAgent.SetDestination(dest);

		var toTarget = navMeshAgent.steeringTarget - navMeshAgent.transform.position;
		var dir = Vector3.SmoothDamp(animator.transform.forward, toTarget, ref currentVelocity, PrepareTime);
		dir.y = 0;
		var rot = Quaternion.FromToRotation(Vector3.forward, dir);
		animator.transform.rotation = rot;

		currentTime += Time.deltaTime;

		if (currentTime >= PrepareTime)
			animator.SetTrigger("preparedToFollow");
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		navMeshAgent.isStopped = false;
		animator.ResetTrigger("preparedToFollow");
	}
}
