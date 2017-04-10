using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollowPlayer : MonoBehaviour {

	public GameObject Player;
	public float moveSpeed;
	Vector3 velocity = Vector3.zero;
	public float smoothTime = .15f;

	void FixedUpdate () {
		if (Player) {
			Vector3 sp = Camera.main.WorldToScreenPoint (transform.position);
			Vector3 dir = (Input.mousePosition - sp).normalized;
			Vector2 n = Vector2.Lerp(transform.position,dir,smoothTime);
			print (dir);
			Vector3 edit = Vector3.SmoothDamp (transform.position, new Vector3 (Player.transform.position.x + n.x, Player.transform.position.y + n.y, transform.position.z), ref velocity, smoothTime * Time.deltaTime);
			//Vector3 roundPos = new Vector3(RoundToNearestPixel(edit.x, GetComponent<Camera>()),RoundToNearestPixel(edit.y,GetComponent<Camera>()), transform.position.z);
			//Vector3 roundPos = Vector3.SmoothDamp(transform.position, new Vector3(Player.transform.position.x,Player.transform.position.y,transform.position.z),ref velocity, smoothTime * Time.deltaTime);

			Vector3 roundPos = new Vector3(RoundToNearestPixel(edit.x, GetComponent<Camera>()),RoundToNearestPixel(edit.y,GetComponent<Camera>()), transform.position.z);
			//transform.position = new Vector3 (Mathf.Clamp(roundPos.x + n.x,roundPos.x -.02f, roundPos.x + .05f),Mathf.Clamp(roundPos.y + n.y,roundPos.y -.02f, roundPos.y + .05f), transform.position.z);
			transform.position = new Vector3(roundPos.x,roundPos.y,transform.position.z);
			print (roundPos);
		}
	}
	public static float RoundToNearestPixel(float unityUnits, Camera view)
	{
		float valueInPixels = (Screen.height / (view.orthographicSize * 2)) * unityUnits;
		valueInPixels = Mathf.Round(valueInPixels);
		float adjustedUnityUnits = valueInPixels / (Screen.height / (view.orthographicSize * 2));
		return adjustedUnityUnits;
	}



}
