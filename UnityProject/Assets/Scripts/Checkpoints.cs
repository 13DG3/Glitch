using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public CheckpointHandler checkHand;
    public SpriteRenderer checkPointSprite;
    public Sprite[] checks;
    public bool isActive;
    // Use this for initialization
    void Start()
    {
        //isActive = false;
        checkPointSprite = GetComponent<SpriteRenderer>();
        checkHand = GameObject.Find("CheckpointManager").GetComponent<CheckpointHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            checkPointSprite.sprite = checks[1];
        }
        else
        {
            checkPointSprite.sprite = checks[0];
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Player2")
            checkHand.UpdateCheckpoint(this.gameObject);
    }
}
