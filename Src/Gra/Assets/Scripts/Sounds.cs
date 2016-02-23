using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent (typeof (AudioSource))]

public class Sounds : MonoBehaviour
{
	public AudioClip BreathJumpSound = null;
	public AudioClip ExplosionSound = null;
	public AudioClip FastdeathSound = null;
	public AudioClip FootstepGravelSound = null;

	public Character Character;
	
	void Start()
    {
      
    }

	void Update()
	{
	
	}

	public void Move()
	{
		if (Character.IsGrounded) 
		{
			GetComponent<AudioSource>().clip = FootstepGravelSound;
			GetComponent<AudioSource>().Play ();
		}

	}

	public void Jump()
	{
		GetComponent<AudioSource>().clip = BreathJumpSound;
		GetComponent<AudioSource>().Play ();
	}

	public void Death()
	{
		GetComponent<AudioSource>().clip = FastdeathSound;
		GetComponent<AudioSource>().Play ();
	}

	public void Explosion()
	{
		GetComponent<AudioSource>().clip = ExplosionSound;
		GetComponent<AudioSource>().Play ();
	}

}


