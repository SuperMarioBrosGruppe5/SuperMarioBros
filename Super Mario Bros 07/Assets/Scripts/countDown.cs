using UnityEngine;
using UnityEngine.UI;

public class countDown : MonoBehaviour {

	private float timeFloat = 399;
	public Text timer;
	int time = 0;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		timer.text = "" + time;
		if (timeFloat > 1) {
			timeFloat -= Time.deltaTime;
		} else {
			timeFloat = 0;
		}
		time = Mathf.FloorToInt(timeFloat);


	}

}
