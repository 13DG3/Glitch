using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLaser : MonoBehaviour {

    public float speed;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public bool isIncreasing;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        move();
	}

    void move()
    {
        if (maxX == minX)
        {
            if (isIncreasing)
            {
                if (gameObject.transform.position.y > maxY)
                    isIncreasing = false;
                gameObject.transform.position += new Vector3(0, Time.deltaTime, 0) * speed;
            }
            else
            {
                if (gameObject.transform.position.y < minY)
                    isIncreasing = true;
                gameObject.transform.position -= new Vector3(0, Time.deltaTime, 0) * speed;
            }
        }
        else
        {
            if (isIncreasing)
            {
                if (gameObject.transform.position.x > maxX)
                    isIncreasing = false;
                gameObject.transform.position += new Vector3(Time.deltaTime, 0, 0) * speed;
            }
            else
            {
                if (gameObject.transform.position.x < minX)
                    isIncreasing = true;
                gameObject.transform.position -= new Vector3(Time.deltaTime, 0, 0) * speed;
            }
        }
    }
}
