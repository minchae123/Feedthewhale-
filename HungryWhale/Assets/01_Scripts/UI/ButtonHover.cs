using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonHover : MonoBehaviour
{
	public void Hover()
	{
		transform.localScale = Vector3.one * 1.05f;
	}

	public void ResetScale()
	{
		transform.localScale = Vector3.one;
	}
}
