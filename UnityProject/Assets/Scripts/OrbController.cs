using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour {
	public GameObject sprite;
	public ParticleSystem part;
	public float curTime;
	public float maxTime = 0.2f;
	public bool shouldDie = false;

	// Use this for initialization
	void Start () {
		curTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate (Vector3.forward * -30 *Time.deltaTime);

		if (shouldDie == true)
			curTime += 1 * Time.deltaTime;

		if (curTime >= maxTime)
			Destroy (this.gameObject);
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag == "Player") {
			GameManager.collectedOrbs += 1;
			print (GameManager.collectedOrbs);
			Destroy (sprite);
			Instantiate (part, transform.position, transform.rotation);
			shouldDie = true;
		}
	}
}
