using UnityEngine;
using System.Collections;

public class ArrowAI : MonoBehaviour {
	
	public int direction;
	public GameObject arrow;
	public Transform spawner;
	public float forceY = 300;
	public float forceX = 1000;

	// Use this for initialization
	IEnumerator Move() {
		while (true) {

			transform.position = new Vector2(transform.position.x,transform.position.y - 0.02f);
			yield return new WaitForSeconds (0.01f);
		}
	}
	
	

		
		
	

	// Update is called once per frame
	
	
	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.gameObject.tag == "Player") {
		
				Invoke ("shoot",0.01f);
			Destroy (this.gameObject, 1f);
			Debug.Log ("Strzelam");
			StartCoroutine ("Move");
			}
			
			

		
		
		
	}
	
	void shoot() {
		// creates item from the list 
		GameObject chooseItem = Instantiate(arrow, new Vector3(spawner.position.x, spawner.position.y,0), Quaternion.identity)as GameObject;
		//use force to pop up the item
		chooseItem.GetComponent<Rigidbody2D>().AddForce (new Vector2(direction * forceX,forceY));

		
	}





}
