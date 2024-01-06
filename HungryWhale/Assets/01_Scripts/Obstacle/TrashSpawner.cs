using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public static TrashSpawner instance { get; private set; }
    public List<GameObject> TrashList = new List<GameObject>();
    public int spawnCount = 0;

    private GameObject player;
    private int maxSpawn = 7;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(TrashSpawn());
    }

    private IEnumerator TrashSpawn()
    {
        if (spawnCount < maxSpawn)
        {
            GameObject trash = Instantiate(TrashList[Random.Range(0,5)], new Vector3(player.transform.position.x + Random.Range(-20f, 20f),Random.Range(-3f, 6.5f), 0), Quaternion.identity);
            trash.GetComponent<Trash>().SetPlayer(player);
            
            spawnCount++;
        }
        yield return null;
        StartCoroutine(TrashSpawn());
    }
}
