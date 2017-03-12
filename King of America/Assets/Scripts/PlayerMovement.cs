using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = .035f; //how fast the player moves.
	public int health = 25; //Player health
	bool isDead; // is the player dead?
	bool facingRight = true; //Is the player facing to the right
	Animator anim;
	void Start()
	{
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		isDead = health <= 0; // if health is less than or equal to zero, then player is dead.
		if (facingRight == true) {
			GetComponent<SpriteRenderer> ().flipX = false; // if player is facing to the right, then don't horizontally flip the sprite.
		}
		else if (facingRight == false) {
			GetComponent<SpriteRenderer> ().flipX = true; // if player is not facing to the right, then horizontally flip the sprite.
		}


	}

	void FixedUpdate () {
		if (!isDead) {
			Movement ();
		}
	}

	void Movement(){
		Vector3 thisPosition = this.transform.position;
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.D)) {
			thisPosition.y += speed / (Mathf.Sqrt(2f));
			thisPosition.x += speed / (Mathf.Sqrt(2f));
			facingRight = true;
			anim.SetTrigger ("Right");
		}
		else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.A)) {
			thisPosition.y += speed / (Mathf.Sqrt(2f));
			thisPosition.x -= speed / (Mathf.Sqrt(2f));
			facingRight = false;
			anim.SetTrigger ("Right");
		}
		else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D)) {
			thisPosition.y -= speed / (Mathf.Sqrt(2f));
			thisPosition.x += speed / (Mathf.Sqrt(2f));
			facingRight = true;
			anim.SetTrigger ("Right");
		}
		else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A)) {
			thisPosition.y -= speed / (Mathf.Sqrt(2f));
			thisPosition.x -= speed / (Mathf.Sqrt(2f));
			facingRight = false;
			anim.SetTrigger ("Right");
		}
		else if (Input.GetKey (KeyCode.W)) {
			thisPosition.y += speed;
			facingRight = true;
			anim.SetTrigger ("Up");
		}
		else if (Input.GetKey (KeyCode.A)) {
			thisPosition.x -= speed;
			facingRight = false;
			anim.SetTrigger ("Right");
		}
		else if (Input.GetKey (KeyCode.D)) {
			thisPosition.x += speed;
			facingRight = true;
			anim.SetTrigger ("Right");
		}
		else if (Input.GetKey (KeyCode.S)) {
			thisPosition.y -= speed;
			facingRight = true;
			anim.SetTrigger ("Down");
		}
		this.transform.position = thisPosition;
	}
}
