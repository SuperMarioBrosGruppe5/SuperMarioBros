using UnityEngine;
using System.Collections;

public class LvlLoader : MonoBehaviour {

	bool playerInZone;

	public string levelToLoad;

	// Use this for initialization
	void Start () {
		playerInZone = false; 
	}
	
	// Update is called once per frame
	void Update () {
		if (playerInZone && Input.GetKeyDown (KeyCode.Return)) {
			Application.LoadLevel(levelToLoad);

		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.name == "SoppSomVelger") {
			playerInZone = true; 

		}
	}
	void OnTriggerExit2D (Collider2D other) {
		if (other.name == "SoppSomVelger") {
				playerInZone = false; 
			
				
		}
	}

}
