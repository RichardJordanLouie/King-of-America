using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

	public GameObject Player;
	public float moveSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 newPos = new Vector3 (Player.transform.position.x, Player.transform.position.y, this.transform.position.z);
		//this.transform.position = Vector3.Lerp (this.transform.position, newPos, moveSpeed * Time.deltaTime);
		this.transform.position = newPos;
	}
}
