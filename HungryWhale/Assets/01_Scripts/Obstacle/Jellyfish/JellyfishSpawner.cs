using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishSpawner : MonoBehaviour
{
    public static JellyfishSpawner instance { get; private set; }
    public GameObject Jellyfish;
    public int spawnCount = 0;

    private GameObject player;
    private int maxSpawn = 4;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(FishSpawn());
    }

    private IEnumerator FishSpawn()
    {
        if (spawnCount < maxSpawn)
        {
            GameObject jellyfish = Instantiate(Jellyfish, new Vector3(player.transform.position.x + Random.Range(-20f, 20f), Random.Range(-2.6f, 10f), 0), Quaternion.identity);
            jellyfish.GetComponent<Jellyfish>().SetPlayer(player);
            int dir = Random.Range(1, 3);
            if (dir == 1) jellyfish.GetComponent<SpriteRenderer>().flipX = true;
            spawnCount++;
        }
        yield return null;
        StartCoroutine(FishSpawn());
    }
}
