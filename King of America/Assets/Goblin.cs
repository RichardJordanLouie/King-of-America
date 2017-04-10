using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour {
	
	public float maximumHealth;
	[HideInInspector]
	public float health;
	public float movementSpeed = .015f;

	private Rigidbody2D myBody;
	private Vector2 direction;
	private CircleCollider2D coll;

	private bool moving;
	private bool walking;
	public float timeBetweenMovements;
	private float timeBetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;

	private Vector2 moveDirection;

	private bool facingRight = true;

	[HideInInspector]
	public bool hurt;
	public GameObject HealthBar;
	public GameObject damageBurst;
	private Animator anim;

	[HideInInspector]
	public bool commenceDestruction = false;
	public float destroyTimer;

	void Start () {
		anim = GetComponent<Animator> ();
		myBody = GetComponent<Rigidbody2D> ();
		timeBetweenMoveCounter = Random.Range(timeBetweenMovements * .3f, timeBetweenMovements);
		timeToMoveCounter = Random.Range(timeToMove * .25f, timeToMove);
	}
	

	void Update () {
		walking = myBody.velocity != Vector2.zero;
		if (!commenceDestruction) {
			if (moving) {
				timeToMoveCounter -= Time.deltaTime;
				facingRight = myBody.velocity.x > 0;
				myBody.velocity = direction * movementSpeed * Time.deltaTime;
				if (timeToMoveCounter <= 0) {
					moving = false;
					timeBetweenMoveCounter = Random.Range (timeBetweenMovements * .3f, timeBetweenMovements);
				}

			} 
			else if (!moving) {
				timeBetweenMoveCounter -= Time.deltaTime;
				myBody.velocity = Vector2.zero;
				if (timeBetweenMoveCounter <= 0f) {
					moving = true;
					timeToMoveCounter = Random.Range (timeToMove * .25f, timeToMove);
					direction = new Vector2 (Random.Range(-1,2),Random.Range(-1,2));
				}
			}
			anim.SetBool ("moving", walking);
			if (myBody.velocity.x != 0)
				anim.SetFloat ("speedX", myBody.velocity.x);
			else
				anim.SetFloat ("speedX", myBody.velocity.y);
		}
	}
}
