using UnityEngine;
using System.Collections;

public class AshesBurner : MonoBehaviour 
{
	public Renderer[] objectsToBurn;

	private ProgressBar timer;

	void Start()
	{
		timer = FindObjectOfType(typeof(ProgressBar)) as ProgressBar;

		if (timer == null)
			Debug.LogError ("No Timer, dude");
	}

	void Update()
	{
		if (timer == null)
			return;

		foreach (Renderer rend in objectsToBurn)
			rend.material.SetFloat ("_SliceAmount", timer.normalizedTime);
	}
}
