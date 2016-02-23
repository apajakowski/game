using UnityEngine;
using System.Collections;

public class SetActive : MonoBehaviour {
	public GameObject exit;
	public float TimeTillActive = 30f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > TimeTillActive)
						exit.SetActive (true);
	}
}
