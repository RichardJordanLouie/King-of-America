using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera cam = GetComponent<Camera> ();
		if (cam.orthographic) {
			cam.orthographicSize = Screen.height / 100f / 2f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
