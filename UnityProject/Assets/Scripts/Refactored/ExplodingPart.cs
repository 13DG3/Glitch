using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingPart : MonoBehaviour {
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private float timer;
    private float period = 2;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        sr.color = new Vector4(sr.color.r, sr.color.g, sr.color.b, 1f-timer/period);
        if (sr.color.a <= 0)
            Destroy(this.gameObject);
    }

    public void Explosion(Vector3 direction, float forcemag)
    {
        rb.AddForce(direction*forcemag);
    }
}
