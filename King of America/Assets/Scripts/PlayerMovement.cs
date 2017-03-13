using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = .035f; //how fast the player moves.
	private int health; //Player health
	public int maximumHealth = 25;
	private bool isDead; // is the player dead?
	private bool facingRight = true; //Is the player facing to the right
	public GameObject healthBar;
	public GameObject staminaBar;
	private Rigidbody2D myBody;
	Animator anim;
	void Start()
	{
		myBody = GetComponent<Rigidbody2D> ();
		health = maximumHealth;
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		healthBar.transform.localScale = new Vector3 (health / maximumHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
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
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.D)) {
			myBody.velocity = new Vector2 ((speed / (Mathf.Sqrt(2f))) * Time.deltaTime,(speed / (Mathf.Sqrt(2f))) * Time.deltaTime);
			facingRight = true;
			anim.SetTrigger ("Right");
			return;
		}
		else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.A)) {
			myBody.velocity = new Vector2 ((-speed / (Mathf.Sqrt(2f))) * Time.deltaTime,(speed / (Mathf.Sqrt(2f))) * Time.deltaTime);
			facingRight = false;
			anim.SetTrigger ("Right");
			return;
		}
		else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D)) {
			myBody.velocity = new Vector2 ((speed / (Mathf.Sqrt(2f))) * Time.deltaTime,(-speed / (Mathf.Sqrt(2f))) * Time.deltaTime);
			facingRight = true;
			anim.SetTrigger ("Right");
			return;
		}
		else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A)) {
			myBody.velocity = new Vector2 ((-speed / (Mathf.Sqrt(2f))) * Time.deltaTime,(-speed / (Mathf.Sqrt(2f))) * Time.deltaTime);
			facingRight = false;
			anim.SetTrigger ("Right");
			return;
		}
		else if (Input.GetKey (KeyCode.W)) {
			myBody.velocity = new Vector2 (0f,speed * Time.deltaTime);
			facingRight = true;
			anim.SetTrigger ("Up");
			return;
		}
		else if (Input.GetKey (KeyCode.A)) {
			myBody.velocity = new Vector2 (-speed * Time.deltaTime, 0);
			facingRight = false;
			anim.SetTrigger ("Right");
			return;
		}
		else if (Input.GetKey (KeyCode.D)) {
			myBody.velocity = new Vector2 (speed * Time.deltaTime,0);
			facingRight = true;
			anim.SetTrigger ("Right");
			return;
		}
		else if (Input.GetKey (KeyCode.S)) {
			myBody.velocity = new Vector2 (0f,-speed * Time.deltaTime);
			facingRight = true;
			anim.SetTrigger ("Down");
			return;
		}
		myBody.velocity = new Vector2 (0f,0f);
	}
}
