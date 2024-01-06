using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    [SerializeField] Camera Cam;

    private int _maxKeyCount = 20;
    private int _currentkeyCount = 0;

    private float _currentTime = 0f;
    private float _clearTime = 5f;
    private float _camShake;
    private float _camDuration;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FastTyping();
        }
    }

    private void FastTyping()
    {
        _currentTime -= Time.deltaTime;

        if (_currentTime > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _currentkeyCount++;
            }

            if (_currentkeyCount == _maxKeyCount)
            {
                ClearGame();
            }
        }
        else
        {
            GameOver();
        }
    }

    private void ClearGame()
    {
        Debug.Log("게임 클리어");
    }
    private void GameOver()
    {
        Debug.Log("게임 오버");
    }
}
