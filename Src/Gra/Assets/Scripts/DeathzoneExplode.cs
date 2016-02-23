using UnityEngine;
using System.Collections;

public class DeathzoneExplode : MonoBehaviour
{
	Character character;
	
	void Start()
	{
		character = GameObject.Find("Character").GetComponent<Character>();
	}
	

	void OnCollisionEnter2D(Collision2D other) {
		
		if (other.gameObject.tag == "Player") {
			character.Explode();
				
				
				
			}

		
		
		

}
}