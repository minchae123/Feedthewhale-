using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgorund : MonoBehaviour
{
    float totalMove;
    public GameObject P;
    private float lastPos;

    private void Update()
    {
        BGMove();
    }

    private void BGMove()
    {
        totalMove = lastPos - P.transform.position.x;
        if (Mathf.Abs(totalMove) > 19.2f)
        {
            transform.position = new Vector3(P.transform.position.x, transform.position.y, 0);
            lastPos = P.transform.position.x;
            totalMove = 0;
        }
    }
}
