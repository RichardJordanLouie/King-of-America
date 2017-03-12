using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfectCamera : MonoBehaviour {

	void Awake()
	{
		var camera = GetComponent<Camera> ();
		if (camera.orthographic) {
			camera.orthographicSize = (Screen.height / 2f) / 100f;
		}
	}
}
