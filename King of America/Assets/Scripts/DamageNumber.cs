using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageNumber : MonoBehaviour {
	public float speed;
	public float damageNumber;
	public Text text;

	void Start()
	{
		text.text = string.Format("{0:0}",damageNumber);
	}

	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);
	}
}
