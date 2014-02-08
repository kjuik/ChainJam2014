using UnityEngine;
using System.Collections;

public class ShaderAnimator : MonoBehaviour 
{
	public string parameter = "_SliceAmount";
	[Range(0f, 1f)]
	public float mapFrom = 0f;
	[Range(0f, 1f)]
	public float mapTo = 1f;
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
			rend.material.SetFloat (parameter, (mapTo - mapFrom) * timer.normalizedTime + mapFrom);
	}
}
