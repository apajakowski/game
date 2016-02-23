using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
    public float speed;
    public float jumpSpeed;
    Vector2 velocity;
    private Animator _animator;

    public Sounds Sounds;

    public Character Character;
    private bool _onMove = false;
    private bool onMove {
        get {
            return _onMove;
        }
        set {
            _onMove = value;
            IsRunning = value;
        }
    }
	public static bool canjump =  true;

    private bool _isRunning = false;
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

    void OnGUI()
    {
        /*if (GUI.Button(new Rect(20, 200, 80, 40), "Left"))
            moveLeft();
        if (GUI.Button(new Rect(110, 200, 80, 40), "Right"))
            moveRight();
        if (GUI.Button(new Rect(200, 200, 80, 40), "Jump"))
            jump();*/
    }
    void Start ()
    {
        _animator = GetComponent<Animator>();
    }
	void Update () {

        velocity = GetComponent<Rigidbody2D>().velocity;
        
        
        if (GameInput.X > 0.1)
        {
            onMove = true;
            moveRight();
        }
        else if (GameInput.X < -0.1)
        {
            onMove = true;
            moveLeft();
        }
        else
        {
            if (!_isJumping)
            {
                onMove = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2((float)velocity.x / 5.1f, velocity.y);
            }
        }
        if (GameInput.Jump)
        {
            onMove = true;
            jump();
        }
       
	}

    void JumpAnimationEnd()
    {
        IsJumping = false;
    }

    void moveRight()
    {
        if(gameObject.GetComponent<Character>().Dead || gameObject.GetComponent<Character>().Dying)
            return;
        velocity.x = speed;
        GetComponent<Rigidbody2D>().velocity = velocity;
        if (gameObject.transform.localScale.x < 0)
        {
            gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
        }
    }
    void moveLeft()
    {
        if (gameObject.GetComponent<Character>().Dead || gameObject.GetComponent<Character>().Dying)
            return;
        velocity.x = speed * -1;
        GetComponent<Rigidbody2D>().velocity = velocity;
        if (gameObject.transform.localScale.x > 0)
        {
            gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
        }
    }
    void jump()
    {
				if (canjump) {
						if (gameObject.GetComponent<Character> ().Dead || gameObject.GetComponent<Character> ().Dying)
								return;
						if (Character.IsGrounded) {
								velocity.y = jumpSpeed;
								GetComponent<Rigidbody2D>().velocity = velocity;
                                Sounds.Jump();
						}
                        //IsJumping = true;
				}
		}

}
