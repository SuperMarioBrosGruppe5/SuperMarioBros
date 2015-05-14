using UnityEngine;
using System.Collections;

public class MarioBigStart : MonoBehaviour {

	Transform player; 
	private SpillerStor spillerStor;

	// Use this for initialization
	void Start () {

		spillerStor = FindObjectOfType<SpillerStor> ();
		StartCoroutine(StartAnim());
		player = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

	}
	IEnumerator StartAnim(){
		spillerStor.enabled = false;	
		spillerStor.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		spillerStor.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		yield return new WaitForSeconds(1);
		spillerStor.enabled = true;
		spillerStor.GetComponent<Rigidbody2D> ().gravityScale = 5f;
		
		
		yield break;
		
	}
}