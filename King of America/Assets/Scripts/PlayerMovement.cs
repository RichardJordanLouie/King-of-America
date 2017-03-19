using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = .035f; //how fast the player moves.
	public float health; //Player health
	public float maximumHealth = 25;
	private bool isDead; // is the player dead?
	public GameObject healthBar;
	public GameObject staminaBar;
	private Rigidbody2D myBody;
	Animator anim;
	[HideInInspector]
	public bool isAttacking = false;

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

		if (health < 0)
			health = 0;
		Animation ();
		if (isAttacking) {
			print (isAttacking);
		}
	}

	void FixedUpdate () {
		if (!isDead && !isAttacking) {
			Movement ();
		}

	}

	void Animation()
	{
		if (myBody.velocity.x == 0f && myBody.velocity.y == 0f) {
			anim.SetBool ("moving", false);
		}
		else if (myBody.velocity.x != 0f || myBody.velocity.y != 0f) {
			anim.SetBool ("moving", true);
		}
		anim.SetFloat ("speedX",myBody.velocity.x);
		anim.SetFloat ("speedY", myBody.velocity.y);
	}

	void Movement(){
		/*
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.D)) {
			myBody.velocity = new Vector2 ((speed / (Mathf.Sqrt(2f))) * Time.deltaTime,(speed / (Mathf.Sqrt(2f))) * Time.deltaTime);
			facingRight = true;
			return;
		}
		else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.A)) {
			myBody.velocity = new Vector2 ((-speed / (Mathf.Sqrt(2f))) * Time.deltaTime,(speed / (Mathf.Sqrt(2f))) * Time.deltaTime);
			facingRight = false;
			return;
		}
		else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D)) {
			myBody.velocity = new Vector2 ((speed / (Mathf.Sqrt(2f))) * Time.deltaTime,(-speed / (Mathf.Sqrt(2f))) * Time.deltaTime);
			facingRight = true;
			return;
		}
		else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A)) {
			myBody.velocity = new Vector2 ((-speed / (Mathf.Sqrt(2f))) * Time.deltaTime,(-speed / (Mathf.Sqrt(2f))) * Time.deltaTime);
			facingRight = false;
			return;
		}
		*/
		/*
		if (Input.GetKey (KeyCode.W)) {
			myBody.velocity = new Vector2 (0f,speed * Time.deltaTime);
			return;
		}
		else if (Input.GetKey (KeyCode.A)) {
			myBody.velocity = new Vector2 (-speed * Time.deltaTime, 0);
			return;
		}
		else if (Input.GetKey (KeyCode.D)) {
			myBody.velocity = new Vector2 (speed * Time.deltaTime,0);
			return;
		}
		else if (Input.GetKey (KeyCode.S)) {
			myBody.velocity = new Vector2 (0f,-speed * Time.deltaTime);
			return;
		}
		*/
		Vector2 move = new Vector2 (Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
		myBody.velocity = move.normalized * speed;
	}
}
