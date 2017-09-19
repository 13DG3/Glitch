using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBar : MonoBehaviour {
    public BoxController bc;
    private Vector3 startPos;
    public float movingFactor = 0.5f;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!bc.isGlitch)
        {
            transform.localScale = new Vector3((1 - bc.curTime / bc.maxTime) * 5.77f, transform.localScale.y, 1);
            transform.position += new Vector3(1, 0, 0)*Time.deltaTime;
            //transform.position = new Vector3(startPos.x + (1 - bc.curTime / bc.maxTime)*movingFactor, transform.position.y, 0);
        }
        
	}
}
