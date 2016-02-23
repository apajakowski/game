using UnityEngine;
using System.Collections;

public class LoadNextLevel : MonoBehaviour {

	public int ChooseLevel = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D other) {
		
		if (other.gameObject.tag == "Player") {
			if(ChooseLevel == 1)
			Application.LoadLevel("Scene1");
			if(ChooseLevel == 2)
			Application.LoadLevel("Scene2");
            if (ChooseLevel == 3)
                Application.LoadLevel("Scene3");
            if (ChooseLevel == 4)
                Application.LoadLevel("Scene4");
            
			if(ChooseLevel == 5)
            {
                GameObject gui = GameObject.Find("Canvas");
                gui.SetActive(false);
                GameObject endScreen =  GameObject.Find("EndScreen");
                endScreen.SetActive(true);
            }
            
			//Application.LoadLevel("Scene3");
		//	if(ChooseLevel == 4)
			//Application.LoadLevel("Scene4");
			
			
			
		}
}
}
