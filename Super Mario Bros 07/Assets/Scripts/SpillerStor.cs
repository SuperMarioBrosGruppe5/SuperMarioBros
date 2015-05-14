using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Kontroller2D))]
public class SpillerStor : MonoBehaviour {

	
	public float hoppHøyde = 4; 
	public float tidTilHopp = .4f;
	float aksTidLufta = .2f;
	float aksTidBakke = .1f;
	float bHastighet = 6;
	
	float sprint = 0f;
	
	float tyngdekraft;
	public static float hoppHastighet;
	public static Vector3 hastighet;
	float hastighetXSmooth;
	bool maxPosReached = false;
	public static BoxCollider2D collider;
	
	Vector2 input;
	
	public static Kontroller2D kontroller;
	
	public static Animator anim;
	public static bool kollisjonOver = false;
	void Start () {
		kontroller = GetComponent<Kontroller2D> ();
		tyngdekraft = -(2 * hoppHøyde) / Mathf.Pow (tidTilHopp, 2); 
		hoppHastighet = Mathf.Abs (tyngdekraft) * tidTilHopp;
		print ("Tyngdekraft: " + tyngdekraft + "Hopp Hastighet: " + hoppHastighet);
		
		anim = GetComponent<Animator>();
		
		collider = GetComponent<BoxCollider2D>();
		
		
	}
	
	
	void Update () {
		
		if (kontroller.kollisjoner.over || kontroller.kollisjoner.under) {
			hastighet.y = 0; 
		}
		
		if (!EnemyAI.playerDead)
		{
			input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
			
		}
		else
		{
			input = new Vector2(0f, 0f);
		}
		
		if (input.x != 0 && input.y == 0)
		{
			anim.SetFloat("Speed", 1);
			anim.SetBool("Grounded", true);
		}
		else
		{
			anim.SetFloat("Speed", 0);
			anim.SetBool("Grounded", true);
			
		}
		
		if (!kontroller.kollisjoner.under)
		{
			anim.SetBool("Grounded", false);
		}
		
		if (Input.GetAxisRaw ("Horizontal") < 0)
		{
			transform.localScale = new Vector3(-1, 1, 1);
			
		}
		else if (Input.GetAxisRaw("Horizontal") > 0)
		{
			transform.localScale = new Vector3(1, 1, 1);
			
		}
		
		if (EnemyAI.playerDead)
		{
			Invoke("Restart", 3);
			
		}
		if (kontroller.kollisjoner.over)
		{
			kollisjonOver = true;
		}
		
		
		if (Input.GetKeyDown (KeyCode.Space) && kontroller.kollisjoner.under && !EnemyAI.playerDead) {
			hastighet.y = hoppHastighet;
			
		}
		
		// totally retarded and complicated code that makes no sense unless you are a geinous who can read newbish stuff, but works. kinda.
		if (transform.position.y < transform.position.y + 5 && !maxPosReached && EnemyAI.playerDead)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y + hoppHastighet * Time.deltaTime, transform.position.z);
		}
		else if ((transform.position.y < transform.position.y + 5 || !maxPosReached) && EnemyAI.playerDead)
		{
			maxPosReached = true;
			transform.position = new Vector3(transform.position.x, transform.position.y - hoppHastighet * Time.deltaTime, transform.position.z);
		}
		
		if (Input.GetKey(KeyCode.LeftShift))
		{
			sprint = 1.5f;
			anim.SetBool("Sprint", true);
		}
		else
		{
			sprint = 1f;
			anim.SetBool("Sprint", false);
			
		}
		
		
		float targetHastighetX = input.x * bHastighet * sprint;
		hastighet.x = Mathf.SmoothDamp (hastighet.x, targetHastighetX, ref hastighetXSmooth, (kontroller.kollisjoner.under)? aksTidBakke:aksTidLufta);
		hastighet.y += tyngdekraft * Time.deltaTime;
		kontroller.Move (hastighet * Time.deltaTime); 
	}
	
	void Restart()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
	
	
}
