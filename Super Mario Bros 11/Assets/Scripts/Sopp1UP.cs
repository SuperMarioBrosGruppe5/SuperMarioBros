using UnityEngine;
using System.Collections;

public class Sopp1UP : MonoBehaviour {


	public GameObject spawnedPoints; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D (Collider2D other) {
		if (other.name == "Sopp1UP(Clone)") {
			
			DestroyObject(other.gameObject);
			Instantiate(spawnedPoints, transform.position, transform.rotation);

		}
		
	}

}
