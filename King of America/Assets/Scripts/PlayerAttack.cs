using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	bool facingRight;
	bool facingLeft;
	bool facingDown;
	bool facingUp;

	bool facingDownLeft;
	bool facingDownRight;
	bool facingUpRight;
	bool facingUpLeft;

	public GameObject Right;
	public GameObject Left;
	public GameObject Up;
	public GameObject Down;
	public GameObject UpRight;
	public GameObject UpLeft;
	public GameObject DownRight;
	public GameObject DownLeft;

	public float coolDown;
	float CD;

	public float lifeTime;
	float LF;
	void Start()
	{
		facingUp = true;
	}

	// Update is called once per frame
	void Update () {
		CD -= Time.deltaTime;
		LF -= Time.deltaTime;

		if (LF <= 0f) {
			Right.SetActive (false);	
			Left.SetActive (false);	
			Up.SetActive (false);	
			Down.SetActive (false);	
			DownRight.SetActive (false);	
			DownLeft.SetActive (false);	
			UpRight.SetActive (false);	
			UpLeft.SetActive (false);	
		}
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.D)) {
			facingUp = false;
			facingDown = false;
			facingRight = false;
			facingLeft = false;
			facingDownLeft = false;
			facingDownRight = false;
			facingUpRight = true;
			facingUpLeft = false;
		}
		else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.A)) {
			facingUp = false;
			facingDown = false;
			facingRight = false;
			facingLeft = false;
			facingDownLeft = false;
			facingDownRight = false;
			facingUpRight = false;
			facingUpLeft = true;
		}
		else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D)) {
			facingUp = false;
			facingDown = false;
			facingRight = false;
			facingLeft = false;
			facingDownLeft = false;
			facingDownRight = true;
			facingUpRight = false;
			facingUpLeft = false;
		}
		else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A)) {
			facingUp = false;
			facingDown = false;
			facingRight = false;
			facingLeft = false;
			facingDownLeft = true;
			facingDownRight = false;
			facingUpRight = false;
			facingUpLeft = false;
		}
		else if (Input.GetKey (KeyCode.W)) {
			facingUp = true;
			facingDown = false;
			facingRight = false;
			facingLeft = false;
			facingDownLeft = false;
			facingDownRight = false;
			facingUpRight = false;
			facingUpLeft = false;
		}
		else if (Input.GetKey (KeyCode.A)) {
			facingUp = false;
			facingDown = false;
			facingRight = false;
			facingLeft = true;
			facingDownLeft = false;
			facingDownRight = false;
			facingUpRight = false;
			facingUpLeft = false;
		}
		else if (Input.GetKey (KeyCode.D)) {
			facingUp = false;
			facingDown = false;
			facingRight = true;
			facingLeft = false;
			facingDownLeft = false;
			facingDownRight = false;
			facingUpRight = false;
			facingUpLeft = false;
		}
		else if (Input.GetKey (KeyCode.S)) {
			facingUp = false;
			facingDown = true;
			facingRight = false;
			facingLeft = false;
			facingDownLeft = false;
			facingDownRight = false;
			facingUpRight = false;
			facingUpLeft = false;
		}

		Attack ();
	
	}
	void Attack()
	{
		if (facingUp && Input.GetKeyDown(KeyCode.Space) && CD <= 0f) 
		{
			CD = coolDown;
			LF = lifeTime;
			Up.SetActive (true);
		}
		else if (facingDown && Input.GetKeyDown(KeyCode.Space) && CD <= 0f) 
		{
			CD = coolDown;
			LF = lifeTime;
			Down.SetActive (true);
		}
		else if (facingLeft && Input.GetKeyDown(KeyCode.Space) && CD <= 0f) 
		{
			CD = coolDown;
			LF = lifeTime;
			Left.SetActive (true);
		}
		else if (facingRight && Input.GetKeyDown(KeyCode.Space) && CD <= 0f) 
		{
			CD = coolDown;
			LF = lifeTime;
			Right.SetActive (true);
		}
		else if (facingUpLeft && Input.GetKeyDown(KeyCode.Space) && CD <= 0f) 
		{
			CD = coolDown;
			LF = lifeTime;
			UpLeft.SetActive (true);
		}
		else if (facingUpRight && Input.GetKeyDown(KeyCode.Space) && CD <= 0f) 
		{
			CD = coolDown;
			LF = lifeTime;
			UpRight.SetActive (true);
		}
		else if (facingDownLeft && Input.GetKeyDown(KeyCode.Space) && CD <= 0f) 
		{
			CD = coolDown;
			LF = lifeTime;
			DownLeft.SetActive (true);
		}
		else if (facingDownRight && Input.GetKeyDown(KeyCode.Space) && CD <= 0f) 
		{
			CD = coolDown;
			LF = lifeTime;
			DownRight.SetActive (true);
		}
	}
}
