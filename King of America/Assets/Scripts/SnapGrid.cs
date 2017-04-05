using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapGrid : MonoBehaviour {
	#if UNITY_EDITOR
	public bool snapToGrid = true;
	public float snapValue = 0.5f;

	public bool sizeToGrid = false;
	public float sizeValue = 0.25f;
	#endif
}
