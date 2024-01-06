using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public int FishCount;

	private void Awake()
	{
		if(Instance != null)
			print("GameManager Error");

		Instance = this;
	}
}
