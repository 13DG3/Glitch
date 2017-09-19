using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatStart : MonoBehaviour {
	public Vector3 startPos;
	// Use this for initialization
	void Awake () {
		transform.position = startPos;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = startPos;
	}
}
