using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawnPoint : MonoBehaviour {
	
	public float spawnDelayTime;
	public GameObject[] slimes;
	bool timerOn = false;
	bool goSpawn;
	public float timer;

	void Start()
	{
		timer = spawnDelayTime;
		foreach (Transform child in this.transform)
		{
			GameObject slime = Instantiate (slimes [Random.Range(0, slimes.Length)], child.transform.position, Quaternion.identity) as GameObject;
			slime.transform.parent = child;
		}
	}
	 
	void Update () {
		if (EmptySpawnPoint ()) {
			
			timerOn = true;
		}
		if (timerOn) {
			timer -= Time.deltaTime;
		}
		if (timer <= 0 && timerOn) {
			timer = spawnDelayTime;
			timerOn = false;
			Spawn ();
		}
	}

	void Spawn()
	{
		
		Transform newSpawnPoint = EmptySpawnPoint ();
		GameObject newSlime = Instantiate (slimes [Random.Range (0, slimes.Length)], newSpawnPoint.transform.position, Quaternion.identity) as GameObject;
		newSlime.transform.parent = newSpawnPoint;
	}

	Transform EmptySpawnPoint()
	{
		foreach (Transform child in this.transform) {
			if (child.transform.childCount == 0) {
				return child.transform;
			}	
		}
		return null;
	}

	void Timer()
	{
		timer = spawnDelayTime;
		timerOn = true;
	}
}
