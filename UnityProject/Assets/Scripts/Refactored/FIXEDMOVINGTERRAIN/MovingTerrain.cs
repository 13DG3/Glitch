using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTerrain : MonoBehaviour {

    public Vector3 targetPos = new Vector3(108.4f, 2.27f,0);
    public bool shouldMove;
    private Vector3 startPos;
    public float speed = 2;

    // Use this for initialization
    void Start () {
        startPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
        if (shouldMove)
        {
            iTween.MoveTo(gameObject, targetPos, speed);
        }
        if (!shouldMove)
        {
            iTween.MoveTo(gameObject, startPos, speed);
        }
    }
}
