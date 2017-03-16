using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour {

	public float health = 10;
	public float movementSpeed = .015f;

	private Rigidbody2D myBody;

	private bool moving;
	public float timeBetweenMovements;
	private float timeBetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;

	private Vector2 moveDirection;

	private bool facingRight = true;
	void Start()
	{
		myBody = GetComponent<Rigidbody2D> ();

		timeBetweenMoveCounter = Random.Range(timeBetweenMovements * .5f, timeBetweenMovements);
		timeToMoveCounter = Random.Range(timeToMove * .75f, timeToMove);
	}

	void Update () {
		if (health <= 0)
			Destroy (gameObject);
		
		if (facingRight) {
			GetComponent<SpriteRenderer> ().flipX = false;
		} 
		else if (!facingRight) {
			GetComponent<SpriteRenderer> ().flipX = true;
		}

		if (moving) {
			timeToMoveCounter -= Time.deltaTime;
			myBody.velocity = moveDirection;
			facingRight = myBody.velocity.x > 0;
			if (timeToMoveCounter <= 0) {
				moving = false;
				timeBetweenMoveCounter = Random.Range(timeBetweenMovements * .5f, timeBetweenMovements);

			}

		}
		else if (!moving) {
			timeBetweenMoveCounter -= Time.deltaTime;
			myBody.velocity = Vector2.zero;
			if (timeBetweenMoveCounter <= 0f) {
				moving = true;
				timeToMoveCounter = Random.Range(timeToMove * .75f, timeToMove);

				moveDirection = new Vector2 (Random.Range(-1f,1f) * movementSpeed,Random.Range(-1f,1f) * movementSpeed);
			}
		}
	}
}		
