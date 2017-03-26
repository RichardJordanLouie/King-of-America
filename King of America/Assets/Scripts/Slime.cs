using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour {

	public float maximumHealth;
	[HideInInspector]
	public float health;
	public float movementSpeed = .015f;

	private Rigidbody2D myBody;
	private Vector2 direction;
	private CircleCollider2D coll;

	private bool moving;
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
	Animator anim;

	[HideInInspector]
	public bool commenceDestruction;
	public float destroyTimer;

	void Start()
	{
		coll = GetComponent<CircleCollider2D> ();
		anim = GetComponent<Animator> ();
		health = maximumHealth;
		myBody = this.gameObject.GetComponent<Rigidbody2D> ();
		timeBetweenMoveCounter = Random.Range(timeBetweenMovements * .3f, timeBetweenMovements);
		timeToMoveCounter = Random.Range(timeToMove * .25f, timeToMove);
	}

	void Update () {
		commenceDestruction = health <= 0;
		HealthBar.GetComponent<SpriteRenderer> ().transform.localScale = new Vector3 (Mathf.Clamp(health / maximumHealth,0, 1f), HealthBar.GetComponent<SpriteRenderer> ().transform.localScale.y, HealthBar.GetComponent<SpriteRenderer> ().transform.localScale.z);
		anim.SetFloat ("hp", health);
		if (commenceDestruction) {
			coll.enabled = false;
			destroyTimer -= Time.deltaTime;
			myBody.velocity = Vector2.zero;
		}
		if (destroyTimer <= 0) {
			Destroy (gameObject);
		}
		if (!commenceDestruction) {
			
			if (facingRight) {
				GetComponent<SpriteRenderer> ().flipX = false;
			} 
			else if (!facingRight) {
				GetComponent<SpriteRenderer> ().flipX = true;
			}

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
		}
	}

	public void hurtAnimation()
	{
		if (!commenceDestruction) {
			anim.SetTrigger ("hurt");
			GameObject copy = Instantiate (damageBurst, transform.position, Quaternion.identity) as GameObject;
		}
	}
}		
