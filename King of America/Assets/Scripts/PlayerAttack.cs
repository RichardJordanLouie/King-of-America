using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public float coolDown;
	private float CD;

	Animator anim;

	void Start()
	{

		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		Attack ();
	}
	void Attack()
	{
		CD -= Time.deltaTime;
		if (Input.GetButtonDown ("Attack") && CD <= 0f) {
			CD = coolDown;
			anim.SetTrigger ("attack");
			GetComponent<PlayerMovement> ().isAttacking = true;
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}
		if (CD <= 0f) {
			GetComponent<PlayerMovement> ().isAttacking = false;
		}
	}
}
