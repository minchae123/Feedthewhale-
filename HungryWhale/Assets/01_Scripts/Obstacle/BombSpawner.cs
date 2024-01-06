using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public static BombSpawner instance { get; private set; }
    public GameObject _Bomb;
    public int spawnCount = 0;

    private GameObject player;
    private int maxSpawn = 3;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        //player = GameObject.Find("Player");
        player = GameManager.Instance.Player;
        StartCoroutine(BombSpawn());
    }

    private IEnumerator BombSpawn()
    {
        if (spawnCount < maxSpawn)
        {
            GameObject bomb = Instantiate(_Bomb, new Vector3(player.transform.position.x + Random.Range(-20f, 20f), player.transform.position.y + Random.Range(-2.6f, 6f), 0), Quaternion.identity);
            bomb.GetComponent<Bomb>().SetPlayer();
            spawnCount++;
        }

        yield return new WaitForSeconds(1.0f); 
        StartCoroutine(BombSpawn());
    }
}