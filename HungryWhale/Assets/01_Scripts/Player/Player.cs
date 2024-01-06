using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public int HP = 100;

	private void Awake()
	{
		
	}

	private void Update()
	{
		
	}


	public void DecreaseHP(int value)
	{
		HP -= value;
	}

	public void IncreaseHP(int value)
	{
		HP += value;
	}
}