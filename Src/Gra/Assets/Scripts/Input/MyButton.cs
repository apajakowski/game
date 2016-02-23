using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyButton : MonoBehaviour {
    private bool _isPressed;

    public bool IsPressed
    {
        get;
        protected set;
    }

    public global::GameInput GameInput
    {
        get
        {
            throw new System.NotImplementedException();
        }
        set
        {
        }
    }

    public void PointerDown()
    {
        IsPressed = true;
    }

    
    public void PointerUp()
    {
        IsPressed = false;
    }
}
