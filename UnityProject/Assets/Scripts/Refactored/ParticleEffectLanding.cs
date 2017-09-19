using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectLanding : MonoBehaviour {
	private ParticleSystem ps;
	private float particleSize;
	public float ParticleSize
	{
		set
		{ 
			particleSize = value;
		}
	}
	[SerializeField]
	private float particleMaxSize = 1.5f;
	[SerializeField]
	private float particleMinSize = 0.5f;
	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 1);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
