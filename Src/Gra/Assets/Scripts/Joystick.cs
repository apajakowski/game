using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    public float Range = 30f;
    public Canvas Canvas;

    private RectTransform _stick;
    private bool _dragging;
    private bool _touched;
    private int _touchId;

    public float X
    {
        get;
        private set;
    }

    public float Y
    {
        get;
        private set;
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

    private void ClampValues()
    {
        float length = Mathf.Sqrt(X * X + Y * Y);
        if (length > 1f)
        {
            float factor = 1f / length;
            X *= factor;
            Y *= factor;
        }
    }


    private void UpdateJoystick()
    {
        ClampValues();

        _stick.localPosition = new Vector2(X * Range, Y * Range);
    }

    // Use this for initialization
    void Start()
    {
        X = 0;
        Y = 0;

        _stick = transform.Find("Stick") as RectTransform;
    }

    public void StartDrag()
    {
        _dragging = true;

        if (Input.touchCount > 0)
        {
            _touched = true;
            for(int i=0; i<Input.touchCount; i++)
                if (Input.GetTouch(i).phase == TouchPhase.Began) {
                    _touchId = i;
                    break;
                }
        }
        
    }

    public void EndDrag()
    {
        _dragging = false;
        _touched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_dragging)
        {
            var position = Input.mousePosition;
            if (_touched)
            {
                var touch = Input.GetTouch(_touchId).position;
                position = new Vector3(touch.x, touch.y, 0);
            }

            position = (position - transform.position) / Canvas.scaleFactor;
            position /= Range;

            X = position.x;
            Y = position.y;
        }
        else
        {
            X = 0;
            Y = 0;
        }

        UpdateJoystick();
    }
}
