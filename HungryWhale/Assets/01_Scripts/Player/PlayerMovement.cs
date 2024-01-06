using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 10;
	private float basicSpeed;
	[SerializeField] private float scaleAmount = 1.1f;

	private SpriteRenderer spriteRenderer;

	private Vector3 dir;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		basicSpeed = moveSpeed;
	}

	private void Update()
	{
		Move();
		Flip();

		if(Input.GetKeyDown(KeyCode.U))
			BigScale();
	}

	public void Move()
	{
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		dir = new Vector2(x, y);

		transform.position += dir * moveSpeed * Time.deltaTime;
	}

	public void Flip()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
		{
			spriteRenderer.flipX = true;
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
		{
			spriteRenderer.flipX = false;
		}
	}

	public void BigScale()
	{
		transform.localScale *= scaleAmount; 
	}

	public void SpeedControl(float speed)
	{
		StartCoroutine(SpeedCool(3, speed));
	}

	IEnumerator SpeedCool(float time, float speed)
	{
		moveSpeed = speed;
		yield return new WaitForSeconds(time);
		moveSpeed = basicSpeed;
	}
}
