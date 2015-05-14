using UnityEngine;
using System.Collections;

public class FørSpill : MonoBehaviour {
	void Start () {

		StartCoroutine(TestCoroutine());

	}
	IEnumerator TestCoroutine(){

		yield return new WaitForSeconds(3);
        Application.LoadLevel(2);

		yield break;

	}
}
