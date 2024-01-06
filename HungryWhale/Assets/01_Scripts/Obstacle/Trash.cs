using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [Header("¿¡¼Â")]
    public List<Sprite> sprites = new List<Sprite>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().DecreaseHP(5);
        }
    }
}
