using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfectCamera : MonoBehaviour {


	Camera camera;

	void Start()
	{
		camera = GetComponent<Camera> ();
		
	}

	void FixedUpdate()
	{
		

		camera.orthographicSize = (Screen.height / 100f) / 2f;
	}
}
