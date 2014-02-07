using UnityEngine;
using System.Collections.Generic;

public class Choice : MonoBehaviour {

	public List<Option> Options;
	public Option CurrentOption;

	public enum Direction {
		UpDown, LeftRight
	}
	public Direction direction;

	void Update(){
		if (direction == Direction.UpDown){
			if (ChainJam.GetButtonJustPressed(ChainJam.BUTTON.UP))
			    OptionUp();
			if (ChainJam.GetButtonJustPressed(ChainJam.BUTTON.DOWN))
			    OptionDown();
		} else {
			if (ChainJam.GetButtonJustPressed(ChainJam.BUTTON.LEFT))
				OptionUp();
			if (ChainJam.GetButtonJustPressed(ChainJam.BUTTON.RIGHT))
				OptionDown();
		}
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
		CurrentOption.Execute();
	}
}
