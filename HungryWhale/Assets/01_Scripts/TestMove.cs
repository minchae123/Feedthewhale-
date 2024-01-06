using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    private void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 5;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * 5;
        transform.position += new Vector3(x, y, 0);
    }
}
