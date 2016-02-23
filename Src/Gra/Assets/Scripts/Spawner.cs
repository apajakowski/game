using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject stone;
	public float timeleft = 30f;
	public float spawnFrequency = 2f;
	// Use this for initialization
	IEnumerator Spawn() {
		while (Time.time < timeleft) {
			GameObject chooseItem = Instantiate(stone, new Vector3(transform.position.x, transform.position.y,0), Quaternion.identity)as GameObject;
			yield return new WaitForSeconds (spawnFrequency);
		}
	}
	
	
	// Use this for initialization
	void Start() {
		StartCoroutine ("Spawn");
		
	}
}
