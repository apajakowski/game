using UnityEngine;
using System.Collections;

public class GameInput : MonoBehaviour
{
    public Joystick Joystick;
    public MyButton JumpButton;

    public static float X
    {
        get;
        private set;
    }

    public static float Y
    {
        get;
        private set;
    }

    public static bool Jump
    {
        get;
        private set;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
            X = Input.GetAxis("Horizontal");
        else
            X = Joystick.X;
        if (Input.GetAxis("Vertical") != 0)
            Y = Input.GetAxis("Vertical");
        else
            Y = Joystick.Y;

        if (Input.GetKey(KeyCode.Space))
            Jump = true;
        else 
            Jump = JumpButton.IsPressed;
    }
}
