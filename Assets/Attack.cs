using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : StateMachineBehaviour
{
	private Player player;
	private NavMeshAgent navMeshAgent;

	public Vector3 target;

	public float attackSpeed = 50f;
	//public float acceleration = 100f;

	private float savedSpeed;
	//private float savedAcceleration;


	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		var playerPos = PlayerManager.Instance.Player.GetComponent<Player>().transform.position;
		var toPlayer = playerPos - animator.transform.position;
		target = animator.transform.position + animator.transform.forward * toPlayer.magnitude;

		navMeshAgent = animator.GetComponent<NavMeshAgent>();
		navMeshAgent.SetDestination(target);

		//savedAcceleration = navMeshAgent.acceleration;
		savedSpeed = navMeshAgent.speed;

		navMeshAgent.speed = attackSpeed;
		//navMeshAgent.acceleration = acceleration;
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		//TODO: check if path partial works?
		if (navMeshAgent.remainingDistance < 0.1f)
			animator.SetTrigger("attackFinished");
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		navMeshAgent.speed = savedSpeed;
		//navMeshAgent.acceleration = savedAcceleration;
		animator.ResetTrigger("attackFinished");
	}
}
