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
	[SerializeField] private BoxCollider2D eatCollider;

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
	}

	public void Move()
	{
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		dir = new Vector2(x, y).normalized;

		if (dir.magnitude > 0)
			player.playerAnimator.SetMove(1);
		else
			player.playerAnimator.SetMove(0);

		Vector3 pos = transform.position + (dir * moveSpeed * Time.deltaTime);
		pos.y = Mathf.Clamp(pos.y, -3.85f, 8.69f);

		transform.position = pos;
	}

	public void Flip()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
		{
			Vector2 offset = new Vector2(0, 0.12f);
			eatCollider.offset = offset;
			spriteRenderer.flipX = false;
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
		{
			Vector2 offset = new Vector2(2.65f, 0.12f);
			eatCollider.offset = offset;
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

	public void SpeedZero()
	{
		moveSpeed = 0;
	}

	public void ResetSpeed()
	{
		moveSpeed = basicSpeed;
	}
}
