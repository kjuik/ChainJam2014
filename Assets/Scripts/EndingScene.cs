using UnityEngine;
using System.Collections;

public class EndingScene : MonoBehaviour {

	public TextMesh Number;

	public Camera MainCamera;
	public Texture2D FadeOutTexture;
	public int FadeOutTime;

	public bool isFadingOut = false;
	float currentAlpha = 0;

	// Use this for initialization
	void Start () {
		Number.text = PointsManager.MaxPoints + " pts";
		GameObject.FindObjectOfType<ChainJam>().AddFunctionBeforeExit(FadeOut,FadeOutTime);
	}

	public void FadeOut(){
		isFadingOut = true;
	}

	void onGUI(){

		if (isFadingOut){
			currentAlpha += Time.deltaTime / FadeOutTime;  
			currentAlpha = Mathf.Clamp01(currentAlpha);   
			
			GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, currentAlpha);
			GUI.depth = -1000;
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), FadeOutTexture);

		}

	}
}
