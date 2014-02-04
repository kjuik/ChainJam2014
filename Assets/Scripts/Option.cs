using UnityEngine;
using System.Collections;

public class Option : MonoBehaviour {

	public bool isChosen;

	public GameObject ChosenObject;

	public Color ChosenColor;
	public Color BasicColor;



	void Update(){

		if (GetComponent<TextMesh>()){
			GetComponent<TextMesh>().color = isChosen ? ChosenColor : BasicColor;
		}
		if (ChosenObject){
			ChosenObject.SetActive(isChosen);
		}
	}
}

