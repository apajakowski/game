using UnityEngine;
using System.Collections;

public class DeathballAI : MonoBehaviour {

	IEnumerator Jump() {
		while (true) {
						GetComponent<Rigidbody2D>().AddForce (Vector2.up * 10);
						yield return new WaitForSeconds (1.4f);
				}
		}


	// Use this for initialization
	void Start() {
		StartCoroutine ("Jump");

	}


}
