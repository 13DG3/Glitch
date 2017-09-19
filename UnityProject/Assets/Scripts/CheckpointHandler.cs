using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour {
	public GameObject[] checkPoints;
    public GameObject[] players;
	// Use this for initialization
	void Start () {
		checkPoints = GameObject.FindGameObjectsWithTag ("Checkpoint");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateCheckpoint(GameObject curCheck){
		foreach (GameObject cp in checkPoints) {
			if (cp.GetComponent<Checkpoints> ().isActive == true) {
				cp.GetComponent<Checkpoints> ().isActive = false;
			}
		}
		curCheck.GetComponent<Checkpoints> ().isActive = true;
	}
}
