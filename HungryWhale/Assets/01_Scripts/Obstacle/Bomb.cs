using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private GameObject player;

    private Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        Check();
    }

    public void SetPlayer()
    {
        //player = p;
        player = GameManager.Instance.Player;
    }

    private void Check()
    {
        if (Vector3.Distance(player.transform.position, transform.position) > 18)
        {
            BombSpawner.instance.spawnCount--;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            Destroy(gameObject);
            player.gameObject.GetComponent<Player>().DecreaseHP(10);
        }
    }
}