using RayWenderlich.Unity.StatePatternInUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{

	public GameObject test;
	public float f_RotSpeed = 3.0f, f_MoveSpeed = 0.01f;
	[SerializeField] public Transform target;    // The target for this enemy. The enemy will try to destroy the target.
	[SerializeField] private float targetDetectionRange = 35f;  // How far the enemy can "sense" the target. This works through walls atm
	[SerializeField] private float targetEngagementRange = 15f; // How far the enemy can shoot at the target
	[SerializeField] private float moveDestinationSetInterval = 0.1f;   // How often the enemy is told to move to the target position.

	[SerializeField] private StateMachine behaviourSM;

	[SerializeField] private EnemyWalkingState walking;
	[SerializeField] private EnemySearchingState searching;
	[SerializeField] private EnemyShootingState shooting;
	[SerializeField] private EnemyPauzeState pauze;
	public Transform Target { get => target; set => target = value; }

	public float TargetDetectionRange { get => targetDetectionRange; set => targetDetectionRange = value; }
	public float TargetEngagementRange { get => targetEngagementRange; set => targetEngagementRange = value; }
	public float MoveDestinationSetInterval { get => moveDestinationSetInterval; set => moveDestinationSetInterval = value; }

	public EnemyWalkingState Walking { get => walking; set => walking = value; }
	public EnemySearchingState Searching { get => searching; set => searching = value; }
	public EnemyPauzeState Pauze { get => pauze; set => pauze = value; }
	public EnemyShootingState Shooting { get => shooting; set => shooting = value; }
	public GameObject sword;

	public void Start()
	{
		target = GameObject.Find("PlayerTrack").GetComponent<Transform>();
		test = GameObject.Find("PlayerTrack");
		target = test.transform;
		behaviourSM = new StateMachine();
		searching = new EnemySearchingState(this, behaviourSM);
		walking = new EnemyWalkingState(this, behaviourSM);
		shooting = new EnemyShootingState(this, behaviourSM);
		pauze = new EnemyPauzeState(this, behaviourSM);

		behaviourSM.Initialize(searching);
	}

	private void Update()
	{
		if (GameManager.gamepauze)
		{
			behaviourSM.ChangeState(pauze); 
			sword.GetComponent<Animator>().enabled = false;
			sword.gameObject.SetActive(false);
		}
		else
		{
			behaviourSM.CurrentState.HandleInput();
			behaviourSM.CurrentState.LogicUpdate();
			transform.rotation = Quaternion.Slerp(transform.rotation
												  , Quaternion.LookRotation(target.position - transform.position)
												  , f_RotSpeed * Time.deltaTime);

			if (behaviourSM.CurrentState == Shooting)
			{
				sword.GetComponent<Animator>().enabled = true;
				sword.gameObject.SetActive(true);
			}
			else
			if (behaviourSM.CurrentState == walking)
			{
				sword.GetComponent<Animator>().enabled = false;
				sword.gameObject.SetActive(true);
			}
			else
			{
				sword.gameObject.SetActive(false);
			}
		}
	}

	public void remove()
	{
		Destroy(gameObject);
	}
	private void FixedUpdate()
	{
		behaviourSM.CurrentState.PhysicsUpdate();
	}
}