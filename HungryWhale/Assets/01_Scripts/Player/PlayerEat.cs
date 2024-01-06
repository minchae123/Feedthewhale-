using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEat : MonoBehaviour
{
	public bool isEatting = false;

	private Player player;

	private void Awake()
	{
		player = GetComponentInParent<Player>();
	}

	private void Update()
	{
		if(Input.GetMouseButton(0))
		{
			isEatting = true;
			player.playerAnimator.SetAttack(isEatting);
		}

		if (Input.GetMouseButtonUp(0))
		{
			isEatting = false;
			player.playerAnimator.SetAttack(isEatting);
		}
	}
}
