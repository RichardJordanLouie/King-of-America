using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speed = .05f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Movement ();
	}

	void Movement(){
		Vector3 thisPosition = this.transform.position;
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.D)) {
			thisPosition.y += speed / (Mathf.Sqrt(2f));
			thisPosition.x += speed / (Mathf.Sqrt(2f));
		}
		else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.A)) {
			thisPosition.y += speed / (Mathf.Sqrt(2f));
			thisPosition.x -= speed / (Mathf.Sqrt(2f));
		}
		else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D)) {
			thisPosition.y -= speed / (Mathf.Sqrt(2f));
			thisPosition.x += speed / (Mathf.Sqrt(2f));
		}
		else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A)) {
			thisPosition.y -= speed / (Mathf.Sqrt(2f));
			thisPosition.x -= speed / (Mathf.Sqrt(2f));
		}
		else if (Input.GetKey (KeyCode.W)) {
			thisPosition.y += speed;
		}
		else if (Input.GetKey (KeyCode.A)) {
			thisPosition.x -= speed;
		}
		else if (Input.GetKey (KeyCode.D)) {
			thisPosition.x += speed;
		}
		else if (Input.GetKey (KeyCode.S)) {
			thisPosition.y -= speed;
		}
		this.transform.position = thisPosition;
	}
}
