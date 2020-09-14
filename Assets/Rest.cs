using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rest : StateMachineBehaviour
{
	private NavMeshAgent navMeshAgent;

	public float RestTime = 2;
	public float RestSpeed = 2f;

	public float currentTime;
	private float savedSpeed;
	private float restStepDest = 1;
	public Vector3 dir;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		navMeshAgent = animator.GetComponent<NavMeshAgent>();
		savedSpeed = navMeshAgent.speed;
		navMeshAgent.speed = RestSpeed;
		currentTime = 0;

		dir = -animator.transform.forward;
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		//var playerPos = PlayerManager.Instance.Player.GetComponent<Player>().transform.position;
		//var toPlayer = playerPos - animator.transform.position;

		//if (toPlayer.sqrMagnitude > Mathf.Epsilon * Mathf.Epsilon)
		//	dir = -toPlayer.normalized;

		navMeshAgent.SetDestination(animator.transform.position + dir * restStepDest);

		currentTime += Time.deltaTime;
		if (currentTime >= RestTime)
			animator.SetTrigger("restFinished");
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		navMeshAgent.speed = savedSpeed;
		animator.ResetTrigger("restFinished");
	}
}
