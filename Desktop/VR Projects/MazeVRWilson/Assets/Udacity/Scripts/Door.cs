using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
    // Create a boolean value called "locked" that can be checked in Update() 
	private bool unlocked;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private Color originalColor;
	private Renderer objectRenderer; 
	public SignPost signPost;
	private AudioSource audio;

	void Start() {
		unlocked = false;
		endPosition = new Vector3 (0.3602068f, 26.17f, 47.65289f);
		objectRenderer = GetComponentInChildren<Renderer> ();
		originalColor = objectRenderer.material.color;
		audio = GetComponent<AudioSource> ();
	}

	void Update() {
       

    }

    public void Unlock()
    {
        // You'll need to set "locked" to true here
		unlocked = true;
    }

	public void OnDoorClicked()
	{
		// If the door is unlocked and it is not fully raised
		// Animate the door raising up
		if (transform.position != endPosition & unlocked) {
			    signPost.ShowSignPost ();
			    audio.Play ();
				transform.position = Vector3.Lerp (transform.position, endPosition, 1.0f);
			}
	}

	public void OnDoorEnter()
	{
		objectRenderer.material.color = Color.green;
	}

	public void OnDoorExit()
	{
		objectRenderer.material.color = originalColor;
	}
}
