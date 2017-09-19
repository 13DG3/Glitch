using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowRF : MonoBehaviour {
    private float defaultCamerScale = 16;
    private Vector3 followPoint;
    public Vector3 FollowPoint
    {
        get
        {
            return followPoint;
        }
    }
    private float cameraScale;
    public float CameraScale
    {
        get
        {
            return cameraScale;
        }
    }
    private bool followingPlayer = true;
	// Use this for initialization
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("changecam"))
		{
			followingPlayer = false;
			ChangeFollowPoint(collision.gameObject.GetComponent<ChangeCameraFocusPoint>());
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("changecam"))
		{
			followingPlayer = true;
		}
	}
	private void ChangeFollowPoint(ChangeCameraFocusPoint ccfp)
	{
		followPoint = ccfp.CamerFocusPos;
		cameraScale = ccfp.CameraScale;
	}
	public void UpdatePlayerFollow()
	{
		if (followingPlayer)
		{
			followPoint = transform.position;
			if (GetComponent<PlayerPhysicsRF>().Grounded || GetComponent<PlayerPhysicsRF>().Grounded)
				cameraScale = defaultCamerScale;
			else
				cameraScale = defaultCamerScale + 1;
		}
	}
}
