using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Anchor : MonoBehaviour
{
    public CinemachineVirtualCamera Cam;
    private CinemachineBasicMultiChannelPerlin _virtualCameraNoise;


    private int _maxKeyCount = 20;
    private int _currentkeyCount = 0;

    private float _currentTime = 0f;
    private float _clearTime = 5f;

    private void Start()
    {
        _currentTime = _clearTime;
    }

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
                StartCoroutine(ShakeCam(0.2f,3f));
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

    IEnumerator ShakeCam(float delay, float value)
    {
        _virtualCameraNoise = Cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        _virtualCameraNoise.m_FrequencyGain = value;
        _virtualCameraNoise.m_AmplitudeGain = value;
        yield return new WaitForSeconds(delay);
        _virtualCameraNoise.m_AmplitudeGain = 0;
        _virtualCameraNoise.m_FrequencyGain = 0;
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
