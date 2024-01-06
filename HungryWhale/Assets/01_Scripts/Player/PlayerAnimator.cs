using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
	private Animator animator;

	private readonly int moveHash = Animator.StringToHash("speed");
	private readonly int attackHash = Animator.StringToHash("attack");


	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	public void SetMove(float speed)
	{
		animator.SetFloat(moveHash, speed);
	}

	public void SetAttack(bool value)
	{
		if (value)
		{
			animator.SetTrigger(attackHash);
		}
		else
		{
			animator.ResetTrigger(attackHash);
		}
	}


}
