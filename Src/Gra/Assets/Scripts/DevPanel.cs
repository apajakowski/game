using UnityEngine;
using System.Collections;

public class DevPanel : MonoBehaviour {
    private bool _active = false;

    public GameObject Joystick;
    public GameObject Button;

	// Use this for initialization
	void Start () {
        if (Application.platform != RuntimePlatform.Android)
        {
            Joystick.SetActive(false);
            Button.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
	}
}
