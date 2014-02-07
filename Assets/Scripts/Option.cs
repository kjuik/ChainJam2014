using UnityEngine;
using System.Collections.Generic;

public class Option : MonoBehaviour {

	public bool isChosen;

	public Color ChosenColor;
	public Color BasicColor; 

	public List<Animation> AnimationsToPlay;
	public List<AudioSource> AudiosToPlay;
	//public int PointsToAdd = 0;
	public string SceneToLoad;
	public float SceneLoadTimeout;

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

		Invoke("loadNextScene",SceneLoadTimeout);
	}

	private void loadNextScene(){
		Application.LoadLevel(SceneToLoad);
	}
}

