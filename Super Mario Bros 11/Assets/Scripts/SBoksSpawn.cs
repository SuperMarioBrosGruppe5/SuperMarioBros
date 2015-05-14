using UnityEngine;
using System.Collections;

public class SBoksSpawn : MonoBehaviour {

	public GameObject spawnedObject;
	
	private int count = 0;

	bool hit = false;
	
	//private sBoksTrigger sBoks;
	//public GameObject otherGameObject;
	Animator anim;
	//Kontroller2D kontroller;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		//kontroller = GetComponent<Kontroller2D>();
		//sBoks = FindObjectOfType<sBoksTrigger> ();
		//anim = sBoks.GetComponent<Animator> ();
		//anim = otherGameObject.GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.DrawRay(transform.position, Vector3.down, Color.green);
		
		//RaycastHit2D under = Physics2D.Raycast(transform.position, Vector3.down, 2f);

		if (hit && count < 1) {

			Debug.Log("njaa");
			Instantiate(spawnedObject, transform.position, transform.rotation);
			count++;
			//anim.SetBool("sBoksHit", true);
		}
	}
	
	
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player" /*&& Spiller.kontroller.kollisjoner.over*/) {
			anim.SetBool ("sBoksHit", true);
			hit = true;

			Debug.Log ("Boks Forandret");

			
		}
		/*if (count < 1) {
			StartCoroutine(spawn());
			Debug.Log ("blit spawnet");
			count++;
		}*/
		
	}
	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Player" /*&& Spiller.kontroller.kollisjoner.over*/) {
			anim.SetBool ("sBoksHit", false); 
			hit = false;
			
		}
	}
	IEnumerator spawn()
	{
		//for (int i = 1; i <= 1; i++) {
			//yield return new WaitForSeconds(0.5f);
			Instantiate(spawnedObject, transform.position, transform.rotation);
			Debug.Log ("Poeng spawn");
			
			yield break;

	//}
	}
}
