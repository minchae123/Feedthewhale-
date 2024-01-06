using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgorund : MonoBehaviour
{
    float totalMove;
    private GameObject Player;
    private float lastPos;

    private void Start()
    {
        Player = GameObject.Find("Player");
    }

    private void Update()
    {
        BGMove();
    }

    private void BGMove()
    {
        totalMove = lastPos - Player.transform.position.x;
        if (Mathf.Abs(totalMove) > 19.2f)
        {
            transform.position = new Vector3(Player.transform.position.x, transform.position.y, 0);
            lastPos = Player.transform.position.x;
            totalMove = 0;
        }
    }
}
