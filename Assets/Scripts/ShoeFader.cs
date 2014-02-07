using UnityEngine;
using System.Collections;

public class ShoeFader : MonoBehaviour 
{
	public float startTime = 0f;
//	public float fadeTime = 2f;

	private bool fading = false;
	private float fadeFrom = 1f;
	public float fadeStep = 0.1f;

	IEnumerator Start () {

		yield return new WaitForSeconds( startTime );

		renderer.material.SetColor ("_Color", new Color (1f, 1f, 1f, 1f));
		fading = true;
	}

	void Update () {

		if (! fading )
			return;

		fadeFrom -= fadeStep;

		if( fadeFrom <= 0f )
		{
			fading = false;
			renderer.material.SetColor ("_Color", new Color (1f, 1f, 1f, 0f));
			return;

		}

		renderer.material.SetColor ("_Color", new Color (1f, 1f, 1f, fadeFrom));
	}
}
