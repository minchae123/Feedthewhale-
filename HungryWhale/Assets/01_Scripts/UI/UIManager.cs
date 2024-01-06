using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	public static UIManager Instance;

	private AudioSource audioSource;

	[SerializeField] private GameObject EscPanel;

	[SerializeField] private Slider hpSlider;

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
}
