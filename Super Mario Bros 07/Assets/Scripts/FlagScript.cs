using UnityEngine;
using System.Collections;

public class FlagScript : MonoBehaviour {

    Transform player;
    Kontroller2D kontroller;
    Spiller spiller;
    Rigidbody2D rigidbody;
    Animator anim;


    bool stopPlayer = true;
    bool moveDown = false;
    bool moveLeft = false;
    bool end = false;



	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        if (player != null && stopPlayer)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            stopPlayer = false;
            moveDown = true;
        }
        if (moveDown)
        {
            print("hello");
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 2f * Time.deltaTime, player.transform.position.z);
            if (player.transform.position.y < 1f)
            {
                moveDown = false;
                moveLeft = true;
            }
        }
        if (moveLeft && anim != null)
        {
           // print("hello");

            player.transform.position = new Vector3(player.transform.position.x + 2f * Time.deltaTime, player.transform.position.y, player.transform.position.z);
            anim.SetBool("Grounded", true);
            anim.SetFloat("Speed", 1f);
            if (player.transform.position.x > 204f)
            {
                moveLeft = false;
                anim.SetFloat("Speed", 0f);
                Invoke("LoadNextLevel", 5);
            }
        }






	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Flag");
        player = other.GetComponent<Transform>();
        kontroller = other.GetComponent<Kontroller2D>();
        spiller = other.GetComponent<Spiller>();
        rigidbody = other.GetComponent<Rigidbody2D>();
        anim = other.GetComponent<Animator>();
         
        Destroy(rigidbody);
        Destroy(spiller);
        Destroy(kontroller);

    }

    void LoadNextLevel()
    {
        Application.LoadLevel(0);
    }
}
