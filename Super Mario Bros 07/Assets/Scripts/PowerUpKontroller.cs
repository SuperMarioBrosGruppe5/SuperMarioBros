using UnityEngine;
using System.Collections;

public class PowerUpKontroller : MonoBehaviour {
		
	public float moveSpeed;
	public bool moveRight;
	
	public Transform veggSjekk;
	public float veggSjekkRadius;
	public LayerMask hvaErVegg;
	private bool treffeVegg; 
	
	//private bool ikkeVedKanten;
	//public Transform kantSjekk;
	
	// Use this for initialization
	void Start () {
		transform.Translate (Vector3.up * 0.5f);

		
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
	
}
