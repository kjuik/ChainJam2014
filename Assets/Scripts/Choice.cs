using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Choice : MonoBehaviour {

	public List<Option> Options;
	public Option CurrentOption;

	public enum Direction {
		UpDown, LeftRight
	}
	public Direction direction;

	void Start(){
		
		foreach (TextMesh m in GameObject.FindObjectsOfType<TextMesh>()){
			if (m.gameObject != this.gameObject)
				StartCoroutine(FadeIn(m));
		}
	}

	private IEnumerator FadeIn(TextMesh m){
		float timeCounter = 0f;
		
		float fadeAwayTimeout = 1f;
		
		while (timeCounter < fadeAwayTimeout){
			
			float alpha = (1f * (timeCounter / fadeAwayTimeout));
			
			m.color = new Color(
				m.color.r,
				m.color.g,
				m.color.b,
				(alpha > 0) ? alpha : 0f
				);
			
			timeCounter += Time.deltaTime;
			
			yield return 0;
		}
		
		m.color = new Color(
			m.color.r,
			m.color.g,
			m.color.b,
			1f
			);
	}

	void Update(){

		if (ChainJam.GetButtonJustPressed(ChainJam.BUTTON.UP))
		    OptionUp();
		if (ChainJam.GetButtonJustPressed(ChainJam.BUTTON.DOWN))
		    OptionDown();
		if (ChainJam.GetButtonJustPressed(ChainJam.BUTTON.LEFT))
			OptionUp();
		if (ChainJam.GetButtonJustPressed(ChainJam.BUTTON.RIGHT))
			OptionDown();

		if (ChainJam.GetButtonJustPressed(ChainJam.BUTTON.A) ||
			ChainJam.GetButtonJustPressed(ChainJam.BUTTON.B))
		    Execute();
	}

	private void OptionUp(){
		int optionNo = Options.IndexOf(CurrentOption);
		int prevOptionNo = optionNo-1;
		if (prevOptionNo < 0) prevOptionNo += Options.Count;
		
		CurrentOption.isChosen = false;
		CurrentOption = Options[prevOptionNo];
		CurrentOption.isChosen = true;
	}

	private void OptionDown(){
		int optionNo = Options.IndexOf(CurrentOption);
		int nextOptionNo = (optionNo+1)%Options.Count;

		CurrentOption.isChosen = false;
		CurrentOption = Options[nextOptionNo];
		CurrentOption.isChosen = true;
	}
	
	private void Execute(){
		GameObject.FindObjectOfType<PointsManager>().audio.Play();
		CurrentOption.Execute();
	}
}
