using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OceanCurrents : MonoBehaviour
{
    private GameObject player;
    private bool isOceanCurrents;

    private void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(ActiveOceanCurrents());
    }

    IEnumerator ActiveOceanCurrents()
    {
        yield return new WaitForSeconds(20);
        player.GetComponent<Rigidbody2D>().AddForce(new Vector3((Random.Range(0, 2) == 0 ? 1 : -1) * 500, 0, 0));
        StartCoroutine(ActiveOceanCurrents());
    }
}
