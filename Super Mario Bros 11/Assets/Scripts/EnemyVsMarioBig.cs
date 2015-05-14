using UnityEngine;
using System.Collections;

public class EnemyVsMarioBig : MonoBehaviour {
	
	 
	public GameObject spawnedObject;
	private SpillerStor spillerStor;
	// Use this for initialization
	void Start () {
		spillerStor = FindObjectOfType<SpillerStor> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D (Collider2D other) {
		if (other.name == "Enemy 1") {
			
			//DestroyObject(other.gameObject);

			StartCoroutine(TestCoroutine());
		}
		
	}
	IEnumerator TestCoroutine(){
		spillerStor.enabled = false;
		//spiller.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		spillerStor.GetComponent<Renderer>().enabled = false;
		//spiller.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		//spiller.GetComponent<Spiller> ().tyngdekraft = 0f; 
		yield return new WaitForSeconds(5);
		Instantiate(spawnedObject, transform.position, transform.rotation);
		spillerStor.enabled = true;
		Destroy(this.gameObject);
		
		
		yield break;
		
	}
}
