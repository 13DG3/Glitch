using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour {
	public float t=1f; // speed
	public float l= 10f;// length from 0 to endpoint.
	public float leftUp = 1;
	public float posX = 1f; // Offset
	public float posY;
	public bool moveSide = true;
	// Use this for initialization
	public float maxX;
	public float minX;
	public float maxY;
	public float minY;
	public bool isIncreasing;
	public bool isPlatform;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (isPlatform)
			move();
		else
		{
			if (moveSide == true)
			{
				Vector3 pos = new Vector3(posX + Mathf.PingPong(t * Time.time, l) * leftUp, posY, 0);
				transform.position = pos;

			}
			else
			{
				Vector3 pos = new Vector3(posX, posY + Mathf.PingPong(t * Time.time, l) * leftUp, 0);
				transform.position = pos;
			}
		}
	}

	void move()
	{
		if (maxX == minX)
		{
			if (isIncreasing)
			{
				if (gameObject.transform.position.y > maxY)
					isIncreasing = false;
				gameObject.transform.position += new Vector3(0, Time.deltaTime, 0) * t;
			}
			else
			{
				if (gameObject.transform.position.y < minY)
					isIncreasing = true;
				gameObject.transform.position -= new Vector3(0, Time.deltaTime, 0) * t;
			}
		}
		else
		{
			if (isIncreasing)
			{
				if (gameObject.transform.position.x > maxX)
					isIncreasing = false;
				gameObject.transform.position += new Vector3(Time.deltaTime, 0, 0) * t;
			}
			else
			{
				if (gameObject.transform.position.x < minX)
					isIncreasing = true;
				gameObject.transform.position -= new Vector3(Time.deltaTime, 0, 0) * t;
			}
		}
	}
}
