using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blowfish : MonoBehaviour
{
    private GameObject _player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _player = collision.gameObject;

        if (_player.tag == "Player")
        {
            StartCoroutine(Damage(5));
        }
    }

    IEnumerator Damage(int value)
    {
        for(int i = 0; i < value; i++)
        {
            _player.GetComponent<Player>().DecreaseHP(1);
            yield return new WaitForSeconds(.1f);
        }
    }
}
