using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour 
{
	[Range(1f, 5f)]
	public float timeLimit = 5f;
	[Range(1f, 10f)]
	public float barMaxLength = 10f;
	[Range(0.1f, 1f)]
	public float barMaxHeight = 0.1f;

	public Color barColor = Color.black;

	public enum CountingDirection { Up, Down };
	public CountingDirection direction = CountingDirection.Up;

	public enum BarPivotPoint { Left = 5, Center = 0, Right = -5 };
	public BarPivotPoint barPivotPoint = BarPivotPoint.Left;
	
	private Transform timerParent = null;
	private float dir = 1f;

	public GameObject sendMessageTo;

	IEnumerator Start()
	{
		timerParent = (new GameObject("Timer Parent Object")).transform;
		timerParent.transform.position = new Vector3(transform.position.x - (float) (int) barPivotPoint * 0.1f,
		                                             transform.position.y,
		                                             transform.position.z);
		transform.parent = timerParent;

		float startLength = direction == CountingDirection.Up ? 0f : barMaxLength;
		dir = direction == CountingDirection.Up ? 1f: -1f;

		timerParent.localScale = new Vector3(startLength, barMaxHeight, 1f);

		renderer.material.color = barColor;

		yield return new WaitForSeconds (timeLimit);

		if( sendMessageTo != null )
			sendMessageTo.SendMessage ("Execute", SendMessageOptions.DontRequireReceiver);
	}

	void Update()
	{
		if( timerParent.localScale.x > barMaxLength || timerParent.localScale.x < 0f )
			return;

		float speed = barMaxLength / timeLimit * dir;
		timerParent.localScale += Vector3.right * speed * Time.deltaTime ;
	}
}
