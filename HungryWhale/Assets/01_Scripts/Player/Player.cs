using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public int HP = 100;

	[HideInInspector]
	public PlayerAnimator playerAnimator;
	[HideInInspector]
	public PlayerEat playerEat;

	public ParticleSystem crazyParticle;

	private SpriteRenderer spriteRenderer;

	private void Awake()
	{
		playerAnimator = GetComponent<PlayerAnimator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		playerEat = GetComponent<PlayerEat>();
	}

	private void Start()
	{
		UIManager.Instance.SliderValue(HP);
	}

	private void Update()
	{

	}

	public void DecreaseHP(int value)
	{
		HP -= value;
		UIManager.Instance.SliderValue(HP);
		StartCoroutine(Blink());
	}

	IEnumerator Blink()
	{
		spriteRenderer.color = Color.red;
		yield return new WaitForSeconds(1);
		spriteRenderer.color = Color.white;
	}

	public void IncreaseHP(int value)
	{
		HP += value;
		UIManager.Instance.SliderValue(HP);
	}

	public void SpinParticle()
	{
		crazyParticle.Play();
	}
}