using UnityEngine;
using System.Collections;

public class PowerUpKontroller : MonoBehaviour {
		
	public float moveSpeed;
	public bool moveRight;
	
	public Transform veggSjekk;
	public float veggSjekkRadius;
	public LayerMask hvaErVegg;
	private bool treffeVegg; 

	private PowerUpKontroller power; 
	//private bool ikkeVedKanten;
	//public Transform kantSjekk;
	
	// Use this for initialization
	void Start () {

		//transform.Translate (Vector3.up * 0.5f);
		power = FindObjectOfType<PowerUpKontroller> ();
		StartCoroutine(TestCoroutine());
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		treffeVegg = Physics2D.OverlapCircle (veggSjekk.position, veggSjekkRadius, hvaErVegg); 
		
		//ikkeVedKanten = Physics2D.OverlapCircle (kantSjekk.position, veggSjekkRadius, hvaErVegg);
		
		if (treffeVegg)
		moveRight = !moveRight;
		//anim.SetBool("moveright", false);
			
		if (moveRight) {
			
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y); 
		} else {
			transform.localScale = new Vector3 (1f, 1f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);			
		}
	}
	IEnumerator TestCoroutine(){
		power.enabled = false;
		power.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		power.GetComponent<CircleCollider2D> ().enabled = false; 
		power.GetComponent<Renderer> ().enabled = false;
		transform.position = new Vector2 (transform.position.x, transform.position.y + 0.1f);
		yield return new WaitForSeconds(0.1f);
		transform.position = new Vector2 (transform.position.x, transform.position.y + 0.15f);

		yield return new WaitForSeconds(0.1f);
		power.GetComponent<Renderer> ().enabled = true;
		transform.position = new Vector2 (transform.position.x, transform.position.y + 0.2f);
		yield return new WaitForSeconds(0.1f);
		transform.position = new Vector2 (transform.position.x, transform.position.y + 0.25f);
		yield return new WaitForSeconds(0.1f);
		transform.position = new Vector2 (transform.position.x, transform.position.y + 0.3f);
		//yield return new WaitForSeconds(1);


		//transform.Translate (Vector3.up * 0.5f);
		//spiller.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		//PowerUpKontroller.GetComponent<Renderer>().enabled = false;
		power.GetComponent<PowerUpKontroller> ().moveSpeed = 0f;
		//spiller.GetComponent<Spiller> ().tyngdekraft = 0f; 
		//yield return new WaitForSeconds(1);
		power.GetComponent<CircleCollider2D> ().enabled = true; 
		power.GetComponent<Rigidbody2D> ().gravityScale = 5f;
		power.GetComponent<PowerUpKontroller> ().moveSpeed = 3f;
		//Instantiate(spawnedObject, transform.position, transform.rotation);
		power.enabled = true;
		//Destroy(this.gameObject);
		
		
		yield break;
		
	}
	
}
