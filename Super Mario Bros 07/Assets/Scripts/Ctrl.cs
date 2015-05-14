using UnityEngine;
using System.Collections;

public class Ctrl : MonoBehaviour
	
{
	void Update ()
	{

		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			Vector3 posisjon = this.transform.position;
			posisjon.y++;
			this.transform.position = posisjon;
		}
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			Vector3 posisjon = this.transform.position;
			posisjon.y--;

			this.transform.position = posisjon;
		}
		if (transform.position.y <= 3.5f) {
			transform.position = new Vector2(transform.position.x, 3.5f);
		} else if (transform.position.y >= 4.5f) {
			transform.position = new Vector2(transform.position.x, 4.5f);
		}
	}
}