using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
	public static UIManager Instance;

	private AudioSource audioSource;

	[SerializeField] private GameObject EscPanel;

	[SerializeField] private Slider hpSlider;
	[SerializeField] private TextMeshProUGUI fishCountTxt;
	[SerializeField] private GameObject fishCountPanel;

	private void Awake()
	{
		if(Instance != null)
			print("UIManager Error");

		audioSource = Camera.main.GetComponent<AudioSource>();

		Instance = this;
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Esc();
		}

		if (Input.GetKeyDown(KeyCode.Q))
		{
			FishCountText(3);
		}
	}

	public void Mute(bool value)
	{
		audioSource.mute = !value;
	}

	public void Esc()
	{
		EscPanel.SetActive(!EscPanel.activeSelf);

		if(EscPanel.activeSelf == true)
			Time.timeScale = 0;
		if(EscPanel.activeSelf == false)
			Time.timeScale = 1;
	}

	public void SceneChange(int num)
	{
		SceneManager.LoadScene(num);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void SliderValue(int value)
	{
		hpSlider.value = value;
	}

	public void FishCountText(int count)
	{
		fishCountTxt.text = "x " + count.ToString();
		StartCoroutine(BigAndSmall());
	}

	IEnumerator BigAndSmall()
	{
		fishCountPanel.transform.DOScale(Vector3.one * 1.1f, 0.2f);
		yield return new WaitForSeconds(0.2f);
		fishCountPanel.transform.DOScale(Vector3.one, 0.2f);
	}
}
