using UnityEngine;
using System.Collections;

public class PointsManager : MonoBehaviour {

	public static int MaxPoints = 0;
	public static int CurrentPoints = 0;

	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}
	
	public static void Add(int points){
		CurrentPoints += points;

		if (CurrentPoints >= MaxPoints){
			MaxPoints = CurrentPoints;
			CommitPoints();
		}
	}

	public static void Reset(){
		CurrentPoints = 0;
	}

	private static void CommitPoints(){
		int cjPoints = ChainJam.GetPoints();
		ChainJam.RemovePoints(cjPoints);
		ChainJam.AddPoints(MaxPoints);
	}
}
