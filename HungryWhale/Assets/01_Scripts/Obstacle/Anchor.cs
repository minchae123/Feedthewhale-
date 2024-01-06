using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using DG.Tweening;
using TMPro;

public class Anchor : MonoBehaviour
{
    public CinemachineVirtualCamera Cam;
    private CinemachineBasicMultiChannelPerlin _virtualCameraNoise;

    private int _maxKeyCount = 20;
    private int _currentkeyCount = 0;

    private float _currentTime = 0f;
    private float _clearTime = 5f;

    private bool isCatch = false;

    public float floatSpeed = 1.0f; // µÕµÕ ¶°´Ù´Ï´Â ¼Óµµ
    public float floatHeight = 1.0f; // µÕµÕ ³ôÀÌ

    private Vector2 startPosition;

	[SerializeField] private Image space;
	[SerializeField] private TextMeshProUGUI spaceTxt;

    private void Start()
    {
        _currentTime = _clearTime;
        startPosition = transform.position;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.TryGetComponent(out Player p))
        {
            isCatch = true;
            p.transform.parent = gameObject.transform;
            float x = Random.Range(2, 4);
            float y = Random.Range(2, 4);
            transform.DOMove(new Vector3(transform.position.x + x, transform.position.y + y, 0), 5);
            FindObjectOfType<PlayerMovement>().SpeedZero();
            FindObjectOfType<OceanCurrents>().StopAllCoroutines();
            StartCoroutine(FadeSpace());
        }
    }

	private void Update()
	{
		if(isCatch)
		{
            FastTyping();
        }

        if(!isCatch)
            Move();
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

    private void Move()
    {
        Vector2 currentPosition = transform.position;

        currentPosition.y = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        transform.position = currentPosition;
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
        FindObjectOfType<PlayerMovement>().ResetSpeed();
        StartCoroutine(NewHoke());

        _virtualCameraNoise = Cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _virtualCameraNoise.m_AmplitudeGain = 0;
        _virtualCameraNoise.m_FrequencyGain = 0;
        space.gameObject.SetActive(false);

        FindObjectOfType<OceanCurrents>().StartCoroutine(FindObjectOfType<OceanCurrents>().ActiveOceanCurrents());

        Destroy(gameObject);
    }

    IEnumerator NewHoke()
	{
		Player p = FindObjectOfType<Player>(); 
        Vector3 pos = new Vector3(p.transform.position.x + Random.Range(-20f, 20f), p.transform.position.y + Random.Range(-2.6f, 7f), 0);
        pos.y = Mathf.Clamp(pos.y, 1.78f, 8f);
        Instantiate(this, pos, Quaternion.identity);
        yield return null;
	}

    private void GameOver()
    {
        Player p = FindObjectOfType<Player>();
        p.transform.parent = null;
    }

    IEnumerator FadeSpace()
	{
        space.gameObject.SetActive(true);
        space.DOFade(0, 0.5f).SetLoops(-1, LoopType.Yoyo);
        spaceTxt.DOFade(0, 0.5f).SetLoops(-1, LoopType.Yoyo);
        yield return null;
    }
}
