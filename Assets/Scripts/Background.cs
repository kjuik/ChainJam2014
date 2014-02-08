using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour 
{
	public bool createBackgroundForThisScene = true;
	public GameObject backgroundPrefab;

	public float zPosRelativeToCam = 10f;

	void Start () {
		DontDestroyOnLoad( gameObject );

		CreateBackground();
	}

	void OnLevelWasLoaded(int level)
	{
		CreateBackground();
	}

	void CreateBackground()
	{
		GameObject back = Instantiate(backgroundPrefab) as GameObject;
		
		back.transform.position = Camera.main.transform.position + Camera.main.transform.forward * zPosRelativeToCam;
		
		float aspect = Camera.main.aspect;
		float fov = Camera.main.fieldOfView;
		
		float height = Mathf.Tan(fov * Mathf.Deg2Rad * 0.5f) * zPosRelativeToCam * 2f;
		
		back.transform.localScale = new Vector3(height * aspect, height, 1f);
	}
}
