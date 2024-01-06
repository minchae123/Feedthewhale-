using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEat : MonoBehaviour
{
	private bool isEatting = false;


	private void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			isEatting = true;
		}
	}


}
