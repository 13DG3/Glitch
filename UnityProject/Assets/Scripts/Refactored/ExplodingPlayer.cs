using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingPlayer : MonoBehaviour {
    [SerializeField]
    private ExplodingPart[] explodingParts;
    private Vector3 targetPos;
    [SerializeField]
    private float explosionForce;
   
    // Use this for initialization
    void Start () {
        foreach (ExplodingPart ep in explodingParts)
        {
            targetPos = ep.transform.position - transform.position;
            ep.GetComponent<Rigidbody2D>().AddForce(targetPos*explosionForce);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (explodingParts[0] == null)
            Destroy(this.gameObject);
	}
}
