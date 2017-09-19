using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatTrigger : MonoBehaviour {
    public MovingPlatforms mp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        mp.enabled = true;        
    }
}
