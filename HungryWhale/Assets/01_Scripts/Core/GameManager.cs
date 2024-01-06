using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public int FishCount;

	public GameObject Player;

	private void Awake()
	{
		if(Instance != null)
			print("GameManager Error");

		Instance = this;

		Player = FindObjectOfType<Player>().gameObject;
	}
}
