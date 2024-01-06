using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    private GameObject player;

    private void Update()
    {
        Check();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Player>().DecreaseHP(5);
        }
    }

    public void SetPlayer(GameObject p)
    {
        player = p;
    }

    private void Check()
    {
        if (Vector3.Distance(player.transform.position, transform.position) > 18)
        {
            JellyfishSpawner.instance.spawnCount--;
            Destroy(gameObject);
        }
    }
}
