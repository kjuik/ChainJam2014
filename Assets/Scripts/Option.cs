using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Option : MonoBehaviour {

	public bool isChosen;

	public Color ChosenColor;
	public Color BasicColor; 

	public List<Animation> AnimationsToPlay;
	public List<AudioSource> AudiosToPlay;
	//public int PointsToAdd = 0;
	public string SceneToLoad;

	void Update(){
		if (GetComponent<TextMesh>()){
			GetComponent<TextMesh>().color = isChosen ? ChosenColor : BasicColor;
		}
	}

	public void Execute(){
		//PointsManager.Add(PointsToAdd);

		foreach(Animation a in AnimationsToPlay)
			a.Play();
		foreach(AudioSource a in AudiosToPlay)
			a.Play();

		foreach (TextMesh m in GameObject.FindObjectsOfType<TextMesh>()){
			if (m.gameObject != this.gameObject)
				StartCoroutine(FadeAway(m));
		}

		(GameObject.FindObjectOfType<ProgressBar>() as ProgressBar).enabled = false;

		Invoke("loadNextScene",1.5f);
	}

	private IEnumerator FadeAway(TextMesh m){
		float timeCounter = 0f;

		float fadeAwayTimeout = 0.5f;

		while (true){

			float alpha = (1f - (1f * (timeCounter / fadeAwayTimeout)));

			m.color = new Color(
				m.color.r,
				m.color.g,
				m.color.b,
				(alpha > 0) ? alpha : 0f
				);


			if (timeCounter > 1f){

				float newAlpha = (1f - (1f * ((timeCounter-1) / fadeAwayTimeout)));

				this.GetComponent<TextMesh>().color = new Color(
					m.color.r,
					m.color.g,
					m.color.b,
					(newAlpha > 0) ? newAlpha : 0f
				);
			}

			timeCounter += Time.deltaTime;

			yield return 0;
		}
	}

	private void loadNextScene(){
		Application.LoadLevel(SceneToLoad);
	}
}

