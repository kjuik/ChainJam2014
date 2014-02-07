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
	private float SceneLoadTimeout = 0.5f;

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

		Invoke("loadNextScene",SceneLoadTimeout);
	}

	private IEnumerator FadeAway(TextMesh m){
		float timeCounter = 0f;

		while (true){

			float alpha = (1f - (1f * (timeCounter / SceneLoadTimeout)));

			m.color = new Color(
				m.color.r,
				m.color.g,
				m.color.b,
				(alpha > 0) ? alpha : 0f
				);
			timeCounter += Time.deltaTime;
			yield return 0;
		}
	}

	private void loadNextScene(){
		Application.LoadLevel(SceneToLoad);
	}
}

