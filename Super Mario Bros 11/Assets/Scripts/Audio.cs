using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {
	public AudioClip boxBreak;	
	public AudioClip jumpSound;

	Kontroller2D kontroller;

	void Start () {	
		kontroller = GetComponent<Kontroller2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (kontroller.kollisjoner.over) {
			AudioSource.PlayClipAtPoint(boxBreak, transform.position);
		}
		if (Input.GetKeyDown (KeyCode.Space) && kontroller.kollisjoner.under) {
			AudioSource.PlayClipAtPoint(jumpSound, transform.position);
		}
	}


}
