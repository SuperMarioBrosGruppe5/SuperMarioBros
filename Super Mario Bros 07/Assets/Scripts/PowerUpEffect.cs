using UnityEngine;
using System.Collections;

public class PowerUpEffect : MonoBehaviour {


	public GameObject spawnedPoints; 
	public GameObject spawnedObject;
	private Spiller spiller;
	// Use this for initialization
	void Start () {
		spiller = FindObjectOfType<Spiller> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D (Collider2D other) {
		if (other.name == "Sopp1(Clone)") {
			
			DestroyObject(other.gameObject);
			Instantiate(spawnedPoints, transform.position, transform.rotation);
			StartCoroutine(TestCoroutine());
		}
		
	}
	IEnumerator TestCoroutine(){
		spiller.enabled = false;
		//spiller.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		spiller.GetComponent<Renderer>().enabled = false;
		//spiller.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		//spiller.GetComponent<Spiller> ().tyngdekraft = 0f; 

		Instantiate(spawnedObject, transform.position, transform.rotation);
		spiller.enabled = true;
		Destroy(this.gameObject);
		
		
		yield break;
		
	}
}
