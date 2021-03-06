﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Maze mazePrefab;

	public Player playerPrefab;

	public Maze mazeInstance;

	public Player playerInstance;
	public static int enemiesCounter = 5;
	public SpawnStuff sp;
	public static bool check;
	public static int level = 1;
	public static bool gamepauze;


	private void Start () {
		check = false;
		StartCoroutine(BeginGame());
	}

	public GameObject biep;
	public IEnumerator BeginGame () {
		Debug.Log(enemiesCounter);
		mazeInstance = Instantiate(mazePrefab) as Maze;
		mazeInstance.Generate();
		yield return StartCoroutine(mazeInstance.Generate());
		playerInstance = Instantiate(playerPrefab) as Player;
		playerInstance.name = "PlayerTrack";
		playerInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));

		sp.SpawnEnemy();
		sp.SpawnPortal();
		sp.SpawnCoin();
		while (!check)
		{
			sp.SpawnPortal();
		}
		Debug.Log(mazeInstance.roomSettings);
	}
}