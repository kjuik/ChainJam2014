using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (ChainJam.GetButtonJustPressed(ChainJam.BUTTON.A))
			Application.LoadLevel("StartScene");
	}
}
