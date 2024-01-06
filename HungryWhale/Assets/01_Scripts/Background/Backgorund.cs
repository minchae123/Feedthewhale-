using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgorund : MonoBehaviour
{
    float totalMove;
    private GameObject player;
    private float lastPos;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        BGMove();
    }

    private void BGMove()
    {
        totalMove = lastPos - player.transform.position.x;
        if (Mathf.Abs(totalMove) > 19.2f)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, 0);
            lastPos = player.transform.position.x;
            totalMove = 0;
        }
    }
}
