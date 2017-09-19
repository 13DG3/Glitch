using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointGlitchInteraction : MonoBehaviour {
    public bool isGlitch = true;
    public GameObject[] players;
    public int glitchesForPuzzle;
    //public Animator anim;
    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (isGlitch == true)
        {

        }

        if (isGlitch == false)
        {
            isGlitch = true;

        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Glitch" && isGlitch)
        {
            isGlitch = false;

        }
        else if (col.gameObject.tag == "Glitch1" && isGlitch)
        {
            isGlitch = false;
            col.GetComponent<PlayerControllerRF>().ResetPlayer(glitchesForPuzzle);
        }
    }
}
