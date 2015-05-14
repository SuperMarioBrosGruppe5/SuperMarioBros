using UnityEngine;
using System.Collections;

public class CoinBlocks : MonoBehaviour {

	/*
    float coinSpeed = 21f;
    Vector3 coinDir;

	public GameObject coinPrefab;
    public GameObject coin;
    
    public bool coinSpawned = false;
    bool coinMaxPosReached = false;
    bool hit = false;



    Kontroller2D kontroller;
    Animator anim;
    //public Kontroller2D.KollisjonInfo kollisjoner = Kontroller2D.instance.kollisjoner;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        kontroller = GetComponent<Kontroller2D>();

    }
	
	// Update is called once per frame
	void Update () {
       
        Debug.DrawRay(transform.position, Vector3.down, Color.green);

        RaycastHit2D under = Physics2D.Raycast(transform.position, Vector3.down, 2f);

        if (hit && !coinSpawned)
        {
            Debug.Log("works");
			coin = (GameObject) Instantiate(coinPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            coinSpawned = true;
            anim.SetBool("BoxHit", true);
        }

        // totally retarded and complicated code that makes no sense unless you are a geinous who can read newbish stuff, but works. kinda.
        if (coin != null && coin.transform.position.y < transform.position.y + 5 && !coinMaxPosReached)
        {
            coin.transform.position = new Vector3(coin.transform.position.x, coin.transform.position.y + coinSpeed * Time.deltaTime, coin.transform.position.z);
        }
        else if(coin != null && (coin.transform.position.y < transform.position.y + 5 || !coinMaxPosReached))
        {
            coinMaxPosReached = true;
            coin.transform.position = new Vector3(coin.transform.position.x, coin.transform.position.y - coinSpeed * Time.deltaTime, coin.transform.position.z);
        }
        if (coin != null && coin.transform.position.y < transform.position.y - 1)
        {
            Destroy(coin);
        }
        
	}


    void OnTriggerEnter2D(Collider2D other)
    {
 
        if (other.tag == "Player" && Spiller.kontroller.kollisjoner.over)
            hit = true;
    }*/
}
