using UnityEngine; using System.Collections;

public class EnemyAI : MonoBehaviour
{

	public GameObject spawnObject; 
	public GameObject spawnObject01;

    public float walkSpeed = 2.0f;
    public float wallLeft = 0.0f;
    public float wallRight = 5.0f;

    public Transform wall1;
    public Transform wall2;

    private bool rightWalk = true;

    float walkingDirection = 1.0f;
    Vector3 walkAmount;

    public static bool playerDead = false;
	public static bool bigPlayerDead = false;



    Animator anim;

    void Start()
    {
		bigPlayerDead = false;
        playerDead = false;
        anim = GetComponent<Animator>();
		 
    }

    // Update is called once per frame
    void Update() {

        RaycastHit2D kill = Physics2D.Raycast(transform.position, Vector3.up, 0.3f);
        RaycastHit2D kill2 = Physics2D.Raycast(new Vector2(transform.position.x + .3f, transform.position.y), Vector3.up, 0.3f);
        RaycastHit2D kill3 = Physics2D.Raycast(new Vector2(transform.position.x - .3f, transform.position.y), Vector3.up, 0.3f);
        RaycastHit2D dead = Physics2D.Raycast(transform.position, Vector3.left, 0.5f);
        RaycastHit2D dead2 = Physics2D.Raycast(transform.position, Vector3.right, 0.5f);



        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;



        if (wall1.transform.position.x + 1.5f > transform.position.x && rightWalk)
        {
            rightWalk = false;                                                 // får den til å gå andre vei
            transform.localScale = new Vector3(-1, 1, 1);                        // snur teksturen
            //Debug.Log("works" + wall1.transform.position.x + " " + transform.position.x);
        }
        else if (rightWalk)
        {
            transform.Translate(-walkAmount);

        }

        if (wall2.transform.position.x - 1.5 < transform.position.x && !rightWalk)
        {
            rightWalk = true;
            transform.localScale = new Vector3(1, 1, 1);

            //Debug.Log("works" + wall2.transform.position.x + " " + transform.position.x);
        }
        else if (!rightWalk)
        {
            transform.Translate(walkAmount);

        } 




        Debug.DrawRay(transform.position, Vector3.up, Color.green);
        Debug.DrawRay(transform.position, Vector3.right, Color.green);
        Debug.DrawRay(transform.position, Vector3.left, Color.green);



        if ((kill.collider && kill.collider.gameObject.name == "Spiller") 
		    || (kill2.collider && kill2.collider.gameObject.name == "Spiller") 
		    	|| (kill3.collider && kill3.collider.gameObject.name == "Spiller")
			|| (kill.collider && kill.collider.gameObject.name == "Spiller(Clone)") 
		    	|| (kill2.collider && kill2.collider.gameObject.name == "Spiller(Clone)") 
		    		|| (kill3.collider && kill3.collider.gameObject.name == "Spiller(Clone)"))
        {

            anim.SetBool("GoombasDead", true);
			Instantiate(spawnObject01, transform.position, transform.rotation);
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.2f);
			walkSpeed = 0f;
			Destroy(this);
			Destroy(this.gameObject, 2f);
			Spiller.hastighet.y = Spiller.hoppHastighet;



			//kill.collider.gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + 10);
        	// Time.timeScale = 0f;
            //Destroy(kill.collider.gameObject);
            // TO-DO Kill the turtle D:
            //EnemyDead enemy = new EnemyDead();
        }
        else if ((dead.collider && dead.collider.gameObject.name == "Spiller")  
		         || (dead2.collider && dead2.collider.gameObject.name == "Spiller")
			|| (dead.collider && dead.collider.gameObject.name == "Spiller(Clone)")  
		         || (dead2.collider && dead2.collider.gameObject.name == "Spiller(Clone)"))
        {
            Spiller.anim.SetBool("Dead", true);
            playerDead = true;
			walkSpeed = 0f;
         
            Spiller.hastighet.y = Spiller.hoppHastighet - 5;
            Kontroller2D.kollisjonMaske.value = 0;


            Spiller.collider.enabled = false;

            //Time.timeScale = 0f;
            //PlayerDead playerDead = new PlayerDead();
            // TO-DO KILL MARIO >:]
            //Destroy(dead2.collider.gameObject);  
            //Destroy(dead.collider.gameObject);
        }
		if ((kill.collider && kill.collider.gameObject.name == "MarioStor(Clone)") 
		    || (kill2.collider && kill2.collider.gameObject.name == "MarioStor(Clone)") 
		    	|| (kill3.collider && kill3.collider.gameObject.name == "MarioStor(Clone)"))
		{
			
			anim.SetBool("GoombasDead", true);
			Instantiate(spawnObject, transform.position, transform.rotation);
			transform.position = new Vector2(transform.position.x, transform.position.y - 0.2f);
			walkSpeed = 0f;
			Destroy(this);
			Destroy(this.gameObject, 2f);
			SpillerStor.hastighet.y = SpillerStor.hoppHastighet;
			
			
			
			//kill.collider.gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + 10);
			// Time.timeScale = 0f;
			//Destroy(kill.collider.gameObject);
			// TO-DO Kill the turtle D:
			//EnemyDead enemy = new EnemyDead();
		}
		else if ((dead.collider && dead.collider.gameObject.name == "MarioStor(Clone)")  
		         || (dead2.collider && dead2.collider.gameObject.name == "MarioStor(Clone)"))
		{
			SpillerStor.anim.SetBool("Dead", true);
			//SpillerStor.KillBigMario(); 
			bigPlayerDead = true;
			//walkSpeed = 0f;
			
			//SpillerStor.hastighet.y = SpillerStor.hoppHastighet = 0f;
			//Kontroller2D.kollisjonMaske.value = 0;
			
			
			//SpillerStor.collider.enabled = false;

		}
	
 }


}