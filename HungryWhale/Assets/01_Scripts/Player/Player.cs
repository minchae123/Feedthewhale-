using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public int HP = 100;

	[HideInInspector]
	public PlayerAnimator playerAnimator;
	[HideInInspector]
	public PlayerEat playerEat;

	private void Awake()
	{
		playerAnimator = GetComponent<PlayerAnimator>();
		playerEat = GetComponent<PlayerEat>();
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