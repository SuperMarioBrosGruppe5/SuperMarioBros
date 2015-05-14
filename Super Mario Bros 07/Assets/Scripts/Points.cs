using UnityEngine;
using System.Collections;

public class Points : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(PointsStart());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator PointsStart(){
		yield return new WaitForSeconds(2);
		Destroy(this.gameObject);
		
		
		yield break;
		
	}
}
