using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public int FishCount;

	public GameObject Player;

	private bool isTen = true;
	private bool isTwenty = true;
	private bool isThirsty = true;
	private bool isForty = true;

	private void Awake()
	{
		if (Instance != null)
			print("GameManager Error");

		Instance = this;

		Player = FindObjectOfType<Player>().gameObject;
	}

	private void Update()
	{
		if (FishCount % 10 == 0 && FishCount != 0)
		{
			if (isTen && FishCount == 10)
			{
				isTen = false;
				Player.transform.localScale *= 1.1f;
				HPReduce();
			}
			if (isTwenty && FishCount == 20)
			{
				isTwenty = false;
				Player.transform.localScale *= 1.1f;
				HPReduce();
			}
			if (isThirsty && FishCount == 30)
			{
				isThirsty = false;
				Player.transform.localScale *= 1.1f;
				HPReduce();
			}
			if (isForty && FishCount == 40)
			{
				isForty = false;
				Player.transform.localScale *= 1.1f;
				HPReduce();
			}
		}

		if (Input.GetKeyDown(KeyCode.B))
			FishCount += 5;
	}

	private void HPReduce()
	{
		FindObjectOfType<Player>().IncreaseHP(10);
	}
}
