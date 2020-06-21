﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayWenderlich.Unity.StatePatternInUnity;

public class EnemyPauzeState : State
{
	public EnemyPauzeState(Enemy agent, StateMachine stateMachine) : base(agent, stateMachine)
	{

	}

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
		Debug.Log("pauze");
		if (!GameManager.gamepauze)
		{
			stateMachine.ChangeState(agent.Searching);
		}
	}
}
