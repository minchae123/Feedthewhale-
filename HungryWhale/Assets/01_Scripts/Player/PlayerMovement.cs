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

	private Player player;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		player = GetComponent<Player>();
		basicSpeed = moveSpeed;
	}

	private void Update()
	{
		Move();
		Flip();

		if (Input.GetKeyDown(KeyCode.U))
			BigScale();
	}

	public void Move()
	{
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		dir = new Vector2(x, y);

		if (dir.magnitude > 0)
			player.playerAnimator.SetMove(1);
		else
			player.playerAnimator.SetMove(0);

		Vector3 pos = transform.position + (dir * moveSpeed * Time.deltaTime);
		pos.y = Mathf.Clamp(pos.y, -4.87f, 6.54f);

		transform.position = pos;
	}

	public void Flip()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
		{
			spriteRenderer.flipX = false;
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
		{
			spriteRenderer.flipX = true;
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
