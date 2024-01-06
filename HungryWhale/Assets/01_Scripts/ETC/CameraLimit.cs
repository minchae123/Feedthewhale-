using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimit : MonoBehaviour
{
	private Player player;
	Vector3 pos;

	private void Awake()
	{
		player = FindObjectOfType<Player>();
	}

	private void Update()
	{
		pos = player.transform.position;
		pos.y = 0;

		transform.position = pos;
	}
}
