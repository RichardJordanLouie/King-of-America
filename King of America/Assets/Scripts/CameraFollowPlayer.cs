using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

	public GameObject Player;
	public float moveSpeed;
	Vector3 velocity = Vector3.zero;
	public float smoothTime = .15f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Player) {
			transform.position = Vector3.SmoothDamp (transform.position, new Vector3 (Player.transform.position.x, Player.transform.position.y, transform.position.z), ref velocity, smoothTime);
		}
		//Vector3 newPos = new Vector3 (Player.transform.position.x, Player.transform.position.y, this.transform.position.z);
		//this.transform.position = Vector3.Lerp (this.transform.position, newPos, moveSpeed * Time.deltaTime);
		//this.transform.position = newPos;
	}
}
