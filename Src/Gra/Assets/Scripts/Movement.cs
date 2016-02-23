using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float DeadZone = .2f;
    public float MaxSpeed = 10f;
    public float Acceleration = 1f;
    public float JumpVelocity = 1f;

    private Animator _animator;
    public float Speed
    {
        get
        {
            return GetComponent<Rigidbody2D>().velocity.x;
        }
        set
        {
            if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > 2)
                IsRunning = true;
            else
                IsRunning = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(value, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    private bool _isRunning;
    private bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        set
        {
            _isRunning = value;
            _animator.SetBool("Running", _isRunning);
        }
    }

    private bool _isCrouching;
    private bool IsCrouching
    {
        get
        {
            return _isCrouching;
        }
        set
        {
            _isCrouching = value;
            _animator.SetBool("Crouching", _isCrouching);
        }
    }

    private bool _isInAir;
    private bool IsInAir
    {
        get
        {
            return GetComponent<Rigidbody2D>().velocity.y != 0;
        }
    }

    private bool _isJumping = false;
    public bool IsJumping
    {
        get
        {
            return _isJumping;
        }
        set
        {
            _isJumping = value;
            _animator.SetBool("Jumping", value);
        }
    }

    private bool _flipped = false;
    public bool Flipped
    {
        get
        {
            return _flipped;
        }
        set
        {
            if (_flipped != value)
                transform.Rotate(0, 180, 0);

            _flipped = value;

        }
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity += new Vector2(0, JumpVelocity);
        if (Speed > 1)
            Speed = MaxSpeed + 3;
        if (Speed < -1)
            Speed = -MaxSpeed - 3;
    }

    void JumpAnimationEnd()
    {
        IsJumping = false;
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!IsInAir)
        {
            if (GameInput.X > DeadZone && !IsCrouching)
                Speed = MaxSpeed;
            else if (GameInput.X < -DeadZone && !IsCrouching)
                Speed = -MaxSpeed;
            else
            {
                Speed *= .95f;
            }

            if (IsCrouching && GameInput.X < -DeadZone)
                Flipped = true;
            if (IsCrouching && GameInput.X > DeadZone)
                Flipped = false;

            if (Speed < 1 && GameInput.Y < -DeadZone)
                IsCrouching = true;
            else
                IsCrouching = false;

        }
        else if (!IsJumping)
        {
            Speed *= .99f;
        }

        if (GameInput.Jump && !IsInAir)
        {
            IsJumping = true;
        }

        if (Speed < 0)
            Flipped = true;
        else if (Speed > 0)
            Flipped = false;

        GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);
    }
}
