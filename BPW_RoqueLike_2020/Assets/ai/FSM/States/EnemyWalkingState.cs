using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RayWenderlich.Unity.StatePatternInUnity;

public class EnemyWalkingState : State
{
	public EnemyWalkingState(Enemy agent, StateMachine stateMachine) : base(agent, stateMachine)
	{
	}

	//public Animator anim;
	public override void Enter()
	{
		base.Enter();
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void LogicUpdate()
	{
		base.LogicUpdate();
			if (Vector3.Distance(agent.transform.position, agent.target.transform.position) < agent.TargetDetectionRange)
			{
				//Debug.Log("HA ZIE JE");
				stateMachine.ChangeState(agent.Walking);
				agent.transform.position += agent.transform.forward * (agent.f_MoveSpeed + 0.75f) * Time.deltaTime;
			}

			if (Vector3.Distance(agent.transform.position, agent.Target.transform.position) < agent.TargetEngagementRange)
			{
				//Debug.Log("nU ZOU IK AANVALLEN");
				stateMachine.ChangeState(agent.Shooting);
			}
			if (Vector3.Distance(agent.transform.position, agent.Target.transform.position) > agent.TargetDetectionRange)
			{
				//Debug.Log("ik zoek");
				stateMachine.ChangeState(agent.Searching);
			}
	}
}
