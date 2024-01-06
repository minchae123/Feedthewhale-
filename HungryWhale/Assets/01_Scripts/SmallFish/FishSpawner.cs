using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public static FishSpawner instance { get; private set; }
    public GameObject smallFish;
    public int spawnCount = 0;

    private GameObject player;
    private int maxSpawn = 10;

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
            GameObject fish = Instantiate(smallFish, new Vector3(player.transform.position.x + Random.Range(-20f, 20f), Random.Range(-2.6f, 10f), 0), Quaternion.identity);
            fish.GetComponent<Fish>().SetPlayer(player);
            int dir = Random.Range(1, 3);
            if (dir == 1) fish.GetComponent<SpriteRenderer>().flipX = true;
            spawnCount++;
        }
        yield return null;
        StartCoroutine(FishSpawn());
    }
}
