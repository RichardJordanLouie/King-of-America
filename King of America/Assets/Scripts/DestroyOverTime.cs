using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {

	public float lifeTime;
	float life;
	void Start()
	{
		life = lifeTime;
	}

	void Update () {
		life -= Time.deltaTime;
		if (life <= 0f) {
			Destroy (gameObject);
		}
	}
}
