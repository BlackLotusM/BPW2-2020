using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStuff : MonoBehaviour
{
    public GameObject portalPrefab;
	public GameObject portalInsta;
	public GameObject enemies;
	public GameObject enemiesprefab;

	public GameObject coin;
	public GameObject coinpre;

	public static int countleft;
	public GameManager gm;
	public float distance;
	public int counter;

	private void Start()
	{
		counter = 0;
	}

	public void SpawnEnemy()
    {
		for (int i = 0; i < GameManager.enemiesCounter; i++)
		{
			enemiesprefab = Instantiate(enemies);
			enemiesprefab.transform.localPosition = gm.mazeInstance.GetCell(gm.mazeInstance.RandomCoordinates).transform.localPosition;
			enemiesprefab.name = "enemie";
			enemiesprefab.tag = "enemy";

			if (Vector3.Distance(enemiesprefab.transform.position, gm.playerInstance.transform.position) <= 2)
			{
				enemiesprefab.gameObject.SetActive(false);
				enemiesprefab.name = "rip";
				enemiesprefab.tag = "rip";
				i--;
			}
		}
	}

	public void SpawnCoin()
	{
		if(GameManager.level == 1)
		{
			for (int i = 0; i < Random.Range(1, 3); i++)
			{
				coinpre = Instantiate(coin);
				coinpre.transform.localPosition = gm.mazeInstance.GetCell(gm.mazeInstance.RandomCoordinates).transform.localPosition;
				coinpre.name = "Coin";
				coinpre.GetComponent<CoinScript>().indexitem = Random.Range(0, 1);
			}
		}
		else if (GameManager.level == 2)
		{
			for (int i = 0; i < Random.Range(1, 10); i++)
			{
				if (Random.Range(1, 10) >= 5)
				{
					coinpre = Instantiate(coin);
					coinpre.transform.localPosition = gm.mazeInstance.GetCell(gm.mazeInstance.RandomCoordinates).transform.localPosition;
					coinpre.name = "Coin";
					coinpre.GetComponent<CoinScript>().indexitem = Random.Range(2, 3);
				}
			}
		}
		else if(GameManager.level == 3)
		{
			for (int i = 0; i < Random.Range(1, 3); i++)
			{
				if (Random.Range(1, 10) >= 7)
				{
					coinpre = Instantiate(coin);
					coinpre.transform.localPosition = gm.mazeInstance.GetCell(gm.mazeInstance.RandomCoordinates).transform.localPosition;
					coinpre.name = "Coin";
					coinpre.GetComponent<CoinScript>().indexitem = Random.Range(4, 5);
				}
				
			}
		}
	}

	public void SpawnPortal()
	{
		counter++;
			portalInsta = Instantiate(portalPrefab);
			portalInsta.transform.localPosition = gm.mazeInstance.GetCell(gm.mazeInstance.RandomCoordinates).transform.localPosition;
			portalInsta.name = "PortalSpawn";
			Debug.Log(Vector3.Distance(portalInsta.transform.position, gm.playerInstance.transform.position));
		distance = Vector3.Distance(portalInsta.transform.position, gm.playerInstance.transform.position);

		if (counter <= 25)
		{
			if (distance > 8)
			{
				GameManager.check = true;
				portalInsta.GetComponent<scripttest>().distance = distance;
			}
			else
			{
				GameManager.check = false;
				Destroy(portalInsta);
			}
		}
		else
		{
			if (counter <= 50)
			{
				if (distance > 6)
				{
					GameManager.check = true;
					portalInsta.GetComponent<scripttest>().distance = distance;
				}
				else
				{
					GameManager.check = false;
					Destroy(portalInsta);
				}
			}
			else
			{
				GameManager.check = true;
			}
		}
	}
}
