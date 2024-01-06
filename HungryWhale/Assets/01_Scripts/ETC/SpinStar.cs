using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinStar : MonoBehaviour
{
    public List<GameObject> stars = new List<GameObject>();
    [SerializeField] private float _rotateSpeed = 8f;
    [SerializeField] private float _distance = 5;

    private void Awake()
    {
        for (int i = 0; i < stars.Count; i++)
        {
            float value = 360 / stars.Count * i;
            Vector3 offset = new Vector3(Mathf.Cos(value * Mathf.Deg2Rad) * Mathf.Rad2Deg, Mathf.Sin(value * Mathf.Deg2Rad) * Mathf.Rad2Deg, 0) * _distance;
            stars[i].transform.localPosition = offset;
        }
    }

    void Update()
    {
        transform.Rotate(transform.up * _rotateSpeed * Time.deltaTime);
    }
}
