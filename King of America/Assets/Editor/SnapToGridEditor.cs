using System;
using UnityEngine;
using UnityEditor;
[InitializeOnLoad]
[CustomEditor(typeof(SnapGrid),true)]
[CanEditMultipleObjects]

public class SnapToGridEditor : Editor {
	public void Start()
	{
		Console.Write ("something");
	}
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI ();

		SnapGrid actor = target as SnapGrid;
		if (actor.snapToGrid)
			actor.transform.position = RoundTransform (actor.transform.position, actor.snapValue);
		if (actor.sizeToGrid)
			actor.transform.localScale = RoundTransform (actor.transform.localScale, actor.sizeValue);
		
	}
	private Vector3 RoundTransform (Vector3 v, float snapValue)
	{
		return new Vector3 (
			snapValue * Mathf.Round (v.x / snapValue),
			snapValue * Mathf.Round (v.y / snapValue),
			v.z

		);
	}

}
