﻿using System.Collections;
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

	private bool dashing;
	private float dashTime;
	public float dTime= .15f;
	Vector3 DashD;

	private bool attackingMove;
	private float attackTime;
	Vector3 attackD;
	private float CD;

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
		Attack();
		if (stamina < maximumStamina)
			stamina += .03f;
		else if (stamina > maximumStamina)
			stamina = maximumStamina;


		if (health < 0)
			health = 0;
		Animation ();
		Dash ();
	}

	void FixedUpdate () {
		if (!isDead) {
			Movement ();
		}
	}

	void Attack()
	{
		CD -= Time.deltaTime;

		attackTime -= Time.deltaTime;
		attackingMove = attackTime > 0;

		if (!attackingMove) {
			attackD = Vector2.zero;
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
		if (Input.GetMouseButtonDown (0) && CD <= 0f) {
			CD = 1f;
			Vector3 sp = Camera.main.WorldToScreenPoint (transform.position);
			Vector3 dir = (Input.mousePosition - sp).normalized;
			attackD = dir * 1f;
			anim.SetTrigger ("attack");
			attackTime = .1f;
		}
		isAttacking = CD > 0f;
		if (Input.GetKeyDown(KeyCode.LeftControl) && dashing == false &&  !isAttacking && stamina >= 5f) {
			stamina -= 5f;
			//GameObject beam = Instantiate (projectile, this.transform.position, Quaternion.identity) as GameObject;
			Vector3 sp = Camera.main.WorldToScreenPoint (transform.position);
			Vector3 dir = (Input.mousePosition - sp).normalized;
			//this.gameObject.GetComponent<Rigidbody2D> ().velocity = dir * 15f;
			DashD = dir * 9f;
			dashTime = dTime;

		}
		dashing = dashTime > 0;
		if (!dashing && !isAttacking)
			myBody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") + DashD.x + attackD.x, Input.GetAxisRaw ("Vertical") + DashD.y + attackD.y) * speed * Time.deltaTime;
		else if (dashing && !isAttacking) {
			myBody.velocity = new Vector2 (DashD.x,DashD.y) * speed * Time.deltaTime;
		}
		else if (!dashing && isAttacking) {
			myBody.velocity = new Vector2 (attackD.x,attackD.y) * speed * Time.deltaTime;
		}
		if (Input.GetAxisRaw ("Horizontal") != 0 && Input.GetAxisRaw ("Vertical") != 0) {
			anim.SetBool ("diagonal", true);
		}
		else {
			anim.SetBool ("diagonal", false);
		}

	}
	void Dash()
	{
		
		dashTime -= Time.deltaTime;

		if (!dashing) {
			DashD = Vector2.zero;
		}
		//Right Dash


		/*
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
		*/
	}

}
