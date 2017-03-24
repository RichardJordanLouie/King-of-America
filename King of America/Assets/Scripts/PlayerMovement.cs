using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = .035f; //how fast the player moves.
	[HideInInspector]
	public float health; //Player health
	public float maximumHealth = 25f;
	public float maximumStamina = 10f; //Player Stamina
	[HideInInspector]
	public float stamina;

	private bool isDead; // is the player dead?
	public GameObject healthBar;
	public GameObject staminaBar;
	private Rigidbody2D myBody;
	Animator anim;
	[HideInInspector]
	public bool isAttacking = false;

	private float dashDelay;
	private int amountPressedD;
	private int amountPressedA;
	private int amountPressedW;
	private int amountPressedS;

	float dashX;
	float dashY;
	private float dashTime;
	float dTime= .15f;

	void Start()
	{
		myBody = GetComponent<Rigidbody2D> ();
		health = maximumHealth;
		stamina = maximumStamina;
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		healthBar.transform.localScale = new Vector3 (health / maximumHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
		staminaBar.transform.localScale = new Vector3 (stamina / maximumStamina, staminaBar.transform.localScale.y, staminaBar.transform.localScale.z);
		isDead = health <= 0; // if health is less than or equal to zero, then player is dead.

		if (stamina < maximumStamina)
			stamina += .03f;
		else if (stamina > maximumStamina)
			stamina = maximumStamina;

		dashTime -= Time.deltaTime;
		if (dashTime <= 0f) {
			dashX = 0;
			dashY = 0;
		}

		if (health < 0)
			health = 0;
		Animation ();
		Dash ();
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

	void Dash()
	{
		//Right Dash
		if (Input.GetKeyDown (KeyCode.D)) {
			amountPressedD += 1;
			amountPressedA = 0;
			amountPressedS = 0;
			amountPressedW = 0;
		} 
		if (amountPressedD == 1 && dashDelay < 0.5f) {
			dashDelay += Time.deltaTime;
		}
		if (amountPressedD == 2 && dashDelay < 0.5f && stamina >= 5f) {
			stamina -= 5f;
			dashX = 3f;
			amountPressedD = 0;
			dashDelay = 0;
			dashTime = dTime;
		}
		if ((dashDelay >= .5f && amountPressedD == 1) || (dashDelay >= .5f && amountPressedD == 2)) {
			amountPressedD = 0;
			dashX = 0f;
			dashDelay = 0;
		}

		//Left Dash
		if (Input.GetKeyDown (KeyCode.A)) {
			amountPressedA += 1;
			amountPressedD = 0;
			amountPressedS = 0;
			amountPressedW = 0;
		} 
		if (amountPressedA == 1 && dashDelay < 0.5f) {
			dashDelay += Time.deltaTime;
		}
		if (amountPressedA == 2 && dashDelay < 0.5f && stamina >= 5f) {
			stamina -= 5f;
			dashX = -3f;
			amountPressedA = 0;
			dashTime = dTime;
			dashDelay = 0;
		}
		if ((dashDelay >= .5f && amountPressedA == 1) || (dashDelay >= .5f && amountPressedA == 2)) {
			amountPressedA = 0;
			dashX = 0f;
			dashDelay = 0;
		}

		//Up Dash
		if (Input.GetKeyDown (KeyCode.W)) {
			amountPressedW += 1;
			amountPressedD = 0;
			amountPressedS = 0;
			amountPressedA = 0;
		} 
		if (amountPressedW == 1 && dashDelay < 0.5f) {
			dashDelay += Time.deltaTime;
		}
		if (amountPressedW == 2 && dashDelay < 0.5f && stamina >= 5f) {
			stamina -= 5f;
			dashY = 3f;
			amountPressedW = 0;
			dashTime = dTime;
			dashDelay = 0;
		}
		if ((dashDelay >= .5f && amountPressedW == 1) || (dashDelay >= .5f && amountPressedW == 2)) {
			amountPressedW = 0;
			dashY = 0f;
			dashDelay = 0;
		}

		//Down Dash
		if (Input.GetKeyDown (KeyCode.S)) {
			amountPressedS += 1;
			amountPressedW = 0;
			amountPressedD = 0;
			amountPressedA = 0;
		} 
		if (amountPressedS == 1 && dashDelay < 0.5f) {
			dashDelay += Time.deltaTime;

		}
		if (amountPressedS == 2 && dashDelay < 0.5f && stamina >= 5f) {
			stamina -= 5f;
			dashY = -3f;
			amountPressedS = 0;
			dashTime = dTime;
			dashDelay = 0;
		}
		if ((dashDelay >= .5f && amountPressedS == 1) || (dashDelay >= .5f && amountPressedS == 2)) {
			amountPressedS = 0;
			dashY = 0f;
			dashDelay = 0;
		}
	}

	void Movement(){
		
		myBody.velocity = new Vector2 (Input.GetAxisRaw("Horizontal") + dashX ,Input.GetAxisRaw("Vertical") + dashY) * speed * Time.deltaTime;
		if (Input.GetAxisRaw ("Horizontal") != 0 && Input.GetAxisRaw ("Vertical") != 0) {
			anim.SetBool ("diagonal", true);
		}
		else {
			anim.SetBool ("diagonal", false);
		}

	}

}
