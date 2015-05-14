using UnityEngine;
using System.Collections;

public class FlagScript : MonoBehaviour {

    Transform player;
    Kontroller2D kontroller;
    Spiller spiller;




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(player != null)
        player.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);




	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Flag");
        player = other.GetComponent<Transform>();
        kontroller = other.GetComponent<Kontroller2D>();
        spiller = other.GetComponent<Spiller>();
        Destroy(spiller);
        Destroy(kontroller);

    }
}
