using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Character : MonoBehaviour {
    private Animator animator;

    private bool _dead;
    private bool _dying;

    private List<Rigidbody2D> limbsRigidBodies;
    private List<Joint2D> limbsJoints;
    private List<Collider2D> limbsColliders;

    public Sounds Sounds;


    public Transform Feet;

    public bool Dead
    {
        get
        {
            return _dead;
        }
        set
        {
            _dead = value;

            // Set animator state
            animator.enabled = !_dead;

            /*if (_dead)
                transform.Translate(0, .05f, 0);*/

            // Turn character into ragdoll by enabling limbs' rigid bodies and colliders 
            foreach (var r in limbsRigidBodies)
                r.isKinematic = !_dead;
            foreach (var c in limbsColliders)
                c.enabled = _dead;

            GetComponent<Rigidbody2D>().isKinematic = _dead;
        }
    }

    public bool Dying
    {
        get
        {
            return _dying;
        }
        set
        {
            _dying = value;

            animator.SetBool("Dying", true);
        }
    }

    public bool IsGrounded
    {
        get
        {
            return Physics2D.Raycast(Feet.position, -Vector3.up, 0.001f);
        }
    }

    public float Speed
    {
        get;
        set;
    }

	// Use this for initialization
	void Start () {

        animator = GetComponent<Animator>();

        limbsColliders = new List<Collider2D>();
        limbsColliders.AddRange(GetComponentsInChildren<PolygonCollider2D>());
        limbsColliders.Remove(GetComponent<BoxCollider2D>());
        limbsColliders.Remove(GetComponent<CircleCollider2D>());

        limbsRigidBodies = new List<Rigidbody2D>();
        limbsRigidBodies.AddRange(GetComponentsInChildren<Rigidbody2D>());
        limbsRigidBodies.Remove(GetComponent<Rigidbody2D>());

        limbsJoints = new List<Joint2D>();
        limbsJoints.AddRange(GetComponentsInChildren<HingeJoint2D>());

        Dead = false;
	}

    public void Die()
    {
        if (Dead)
            return;

        Dead = true;
        Sounds.Death();
    }

    public void Explode ()
    {
        if (Dead)
            return;

        foreach (Transform child in GetAllChildren(transform).ToList())
        {
            child.parent = null;

            var direction = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            var r = child.gameObject.GetComponent<Rigidbody2D>();
            if (r != null) 
                child.gameObject.GetComponent<Rigidbody2D>().velocity += direction;
        }

        foreach (var j in limbsJoints)
            j.enabled = false;


        Dead = true;

        Sounds.Explosion();
    }

    IEnumerable<Transform> GetAllChildren(Transform transform)
    {
        foreach (Transform child in transform)
        {
            yield return child;
            foreach (var c in GetAllChildren(child))
                yield return c;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Dead || Dying)
            return;

	}

    public float distToGround { get; set; }

    public global::Gui Gui
    {
        get
        {
            throw new System.NotImplementedException();
        }
        set
        {
        }
    }

    public global::Deathzone Deathzone
    {
        get
        {
            throw new System.NotImplementedException();
        }
        set
        {
        }
    }

    public global::DeathzoneExplode DeathzoneExplode
    {
        get
        {
            throw new System.NotImplementedException();
        }
        set
        {
        }
    }

    public global::Sounds Sounds1
    {
        get
        {
            throw new System.NotImplementedException();
        }
        set
        {
        }
    }

    public global::CharacterMovement CharacterMovement
    {
        get
        {
            throw new System.NotImplementedException();
        }
        set
        {
        }
    }
}
