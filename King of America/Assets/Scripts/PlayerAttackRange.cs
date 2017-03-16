using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackRange : MonoBehaviour {
	public int damage = 5;

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.transform.tag == "Enemy") {
			if (col.transform.GetComponent<Slime> ()) {
				float hp = col.transform.GetComponent<Slime> ().health;
				col.transform.GetComponent<Slime>().health = Health.DamageHealth (hp, damage);
			}
		}
	}
}
