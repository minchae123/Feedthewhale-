using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blowfish : MonoBehaviour
{
    private GameObject _player;

    public float floatSpeed = 0.8f; // µÕµÕ ¶°´Ù´Ï´Â ¼Óµµ
    public float floatHeight = 1.2f; // µÕµÕ ³ôÀÌ

    private Vector2 startPosition;

    private SpriteRenderer spriteRenderer;
    public Sprite wow;
    public Sprite basic;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		Move();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _player = collision.gameObject;

        if (_player.tag == "Player")
        {
            spriteRenderer.sprite = wow;
            StartCoroutine(Damage(5));
            StartCoroutine(Kind());
        }
    }


    IEnumerator Kind()
	{
        yield return new WaitForSeconds(5);
        spriteRenderer.sprite = basic;
	}

    private void Move()
    {
        Vector2 currentPosition = transform.position;

        currentPosition.y = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        transform.position = currentPosition;
    }

    IEnumerator Damage(int value)
    {
        for(int i = 0; i < value; i++)
        {
            FindObjectOfType<Player>().DecreaseHP(1);
            yield return new WaitForSeconds(.1f);
        }
    }
}
