using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour {
	public Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.constraints == RigidbodyConstraints2D.FreezeAll) { 
			rb.constraints = RigidbodyConstraints2D.FreezeAll;
		} else {
			rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
		}
	}
}
