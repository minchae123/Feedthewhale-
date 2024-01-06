using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius = 3f; 
    public GameObject explosionEffect;
    public float fuseTime = 3f;

    private GameObject player;

    private void Start()
    {
        // 코루틴 시작
        Check();
        StartCoroutine(StartFuse());
    }

    public void SetPlayer(GameObject p)
    {
        player = p;
    }

    private void Check()
    {
        if (Vector3.Distance(player.transform.position, transform.position) > 18)
        {
            BombSpawner.instance.spawnCount--;
            Destroy(gameObject);
        }
    }

    private IEnumerator StartFuse()
    {
        yield return new WaitForSeconds(fuseTime);

        Explode();
    }

    private void Explode()
    {
        
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D hitCollider in colliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                player.gameObject.GetComponent<Player>().DecreaseHP(10);
            }
        }
        BombSpawner.instance.spawnCount--;
        Destroy(gameObject);
    }
}