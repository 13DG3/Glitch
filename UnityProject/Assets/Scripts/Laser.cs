using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
	private LineRenderer lineRend;
	public Transform laserHit;
	private Vector3 startPos;   
	private Vector3 endPos; 
	public bool isDang = true;
	public GameObject[] checkPoints;
	public GameObject player;
	public GameObject player2;
	private Vector3 initialPos;
	//public Vector2 laserDir = transform.right;

	// Use this for initialization
	void Start () {
		checkPoints = GameObject.FindGameObjectsWithTag ("Checkpoint");
		player = GameObject.FindGameObjectWithTag ("Player");
		player2 = GameObject.FindGameObjectWithTag ("Player2");
		lineRend = GetComponent<LineRenderer> ();
		lineRend.enabled = true;
		lineRend.useWorldSpace = true;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
		initialPos = hit.point;
	}

	// Update is called once per frame
	void Update() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
		if (hit.collider.gameObject.tag == "explodingplayer" && isDang)
			Debug.DrawLine(transform.position, initialPos);
		else
			Debug.DrawLine(transform.position, hit.point);
		laserHit.position = hit.point;
		lineRend.SetPosition(0, transform.position);
		lineRend.SetPosition(1, laserHit.position);

		if ((hit.collider.gameObject.tag == "Player" || hit.collider.gameObject.tag == "Glitch1") && isDang) {

			foreach (GameObject cp in checkPoints) {
				if (cp.GetComponent<Checkpoints>().isActive == true) {
					player.GetComponent<PlayerRespawnRF>().PlayerRespawnLocation = cp.transform.position;
					player.GetComponent<PlayerRespawnRF>().ShouldRespawn = true;
				}
			}
		}

		if ( (hit.collider.gameObject.tag == "Player2" || hit.collider.gameObject.tag == "Glitch") && isDang) {

			foreach (GameObject cp in checkPoints) {
				if (cp.GetComponent<Checkpoints> ().isActive == true) {
					player2.GetComponent<PlayerRespawnRF>().PlayerRespawnLocation = cp.transform.position;
					player2.GetComponent<PlayerRespawnRF>().ShouldRespawn = true;
				}
			}
		}
	}
}
