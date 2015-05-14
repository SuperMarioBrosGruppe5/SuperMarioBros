using UnityEngine;
using System.Collections;

public class countDown : MonoBehaviour {
	GUIStyle fontSize;
	public int Size;
	public Font font;
	public float timeFloat = 5;

	public int left;
	public int top;

    GUIText text;

	int time = 0;
	// Use this for initialization
	void Start () {
		fontSize = new GUIStyle();
		fontSize.fontSize = Size;
        text = GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {

        text.text = "TIME: " + time;

		if (timeFloat > 1) {
			timeFloat -= Time.deltaTime;
		} else {
			timeFloat = 0;
		}
		time = Mathf.FloorToInt(timeFloat);
	}
	void OnGUI(){
		GUI.skin.font = font;
		fontSize.normal.textColor = Color.white;
			GUI.Label (new Rect (left, top, 200, 100), ""+time , fontSize);
	}	
}
