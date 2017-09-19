using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnRF : MonoBehaviour {
    private Rigidbody2D rb;
    private Vector3 playerRespawnLocation;
    public Vector3 PlayerRespawnLocation
    {
        set
        {
            playerRespawnLocation = value;
        }
    }
    private float respawnTimer;
    [SerializeField]
    private float respawnPeriod = 0.5f;

    private bool shouldRespawn;
    public bool ShouldRespawn
    {
        set
        {
            shouldRespawn = value;
        }
        get
        {
            return shouldRespawn;
        }
    }
    
	[SerializeField]
	private GameObject[] deathAnims;
	[SerializeField]
	private BoxCollider2D gb;


	public void SetUpPlayerRespawn()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	public void UpdatePlayerRespawn(bool direction)
	{
		Respawn(direction);
	}

	private void Respawn(bool direction)
	{
		if (shouldRespawn)
		{
			respawnTimer += Time.deltaTime;
			rb.constraints = RigidbodyConstraints2D.FreezeAll;
			if (GetComponent<SpriteRenderer>().enabled)
			{
				GetComponent<SpriteRenderer>().enabled = false;
				//if(direction)
					Instantiate(deathAnims[0], transform.position, Quaternion.identity);
				//else
					//Instantiate(deathAnims[1], transform.position, Quaternion.identity);
				GetComponent<BoxCollider2D>().enabled = false;
				GetComponent<CircleCollider2D>().enabled = false;
				gb.enabled = false;
			}
			if (respawnTimer > respawnPeriod)
			{
				respawnTimer = 0;
				transform.position = playerRespawnLocation;
				GetComponent<SpriteRenderer>().enabled = true;
				shouldRespawn = false;
				rb.constraints = RigidbodyConstraints2D.None;
				rb.constraints = RigidbodyConstraints2D.FreezeRotation;
				GetComponent<CircleCollider2D>().enabled = true;
				GetComponent<BoxCollider2D>().enabled = true;
				gb.enabled = true;
			}
		}
	}

}
