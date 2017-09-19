using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
	public Transform [] backgrounds;
	private float[] parallaxScales;
	public float smoothing = 1f;
	private Vector3 prevCamPos;

	void Awake(){
	}
	// Use this for initialization
	void Start () {
		prevCamPos = transform.position;
		parallaxScales = new float[backgrounds.Length];

		for (int i = 0; i < parallaxScales.Length; i++) {
			parallaxScales [i] = backgrounds [i].position.z * -1;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		for (int i = 0; i < backgrounds.Length; i++) {
			Vector3 parralax = (prevCamPos - transform.position) *(parallaxScales[i]/smoothing);
			backgrounds [i].position = new Vector3 (backgrounds [i].position.x + parralax.x, backgrounds [i].position.y + parralax.y, backgrounds [i].position.z);
			/*Vector3 foregroundTargetPos = new Vector3 (foregroundTargetPosX, foregrounds [i].position.y, foregrounds [i].position.z);

			float parallax = (prevCamPos.x - cam.position.x) * parallaxScales [i];

			float foregroundTargetPosX = foregrounds [i].position.x + parallax;


			foregrounds [i].position = Vector3.Lerp (foregrounds [i].position, foregroundTargetPos, smoothing * Time.deltaTime);*/

		}

		prevCamPos = transform.position;
	}
}
