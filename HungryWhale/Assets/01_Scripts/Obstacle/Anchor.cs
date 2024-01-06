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

    private bool isCatch = false;

    public float moveSpeed = 5f; // 이동 속도
    public float changeInterval = 2f; // 방향 변경 주기

    private float timer; // 경과 시간
    private Vector3 randomDirection; // 랜덤한 이동 방향

    private void Start()
    {
        _currentTime = _clearTime;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.TryGetComponent(out Player p))
        {
            isCatch = true;
            p.transform.parent = gameObject.transform;
        }
    }

	private void Update()
	{
		if(isCatch)
		{
            timer += Time.deltaTime;
            if (timer >= changeInterval)
            {
                SetRandomDirection();
                timer = 0f;
            }

            transform.Translate(randomDirection * moveSpeed * Time.deltaTime);

            FastTyping();

        }
    }

    void SetRandomDirection()
    {
        randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
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
        isCatch = false;
        Player p = FindObjectOfType<Player>();
        p.transform.parent = null;
    }

    private void GameOver()
    {
        Player p = FindObjectOfType<Player>();
        p.transform.parent = null;
        print("게임 오바");
    }
}
