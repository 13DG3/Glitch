using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

public class CameraControllerRF : MonoBehaviour {
    private PlayerSwitchRF ps;
    private PlayerFollowRF pf;
    private AnalogGlitch ag;

    private Vector3 followPos;
    private float cameraScale;
    private float dampTime = 0.35f;
    private Vector3 velocity = Vector3.zero;
    private Camera cam;
    [SerializeField]
    private float scaleSpeed =1;

    public AnimationCurve ac;
    private float timer;
	// Use this for initialization
	void Start ()
    {
        ag = GetComponent<AnalogGlitch>();
        cam = GetComponent<Camera>();
        ps = GetComponent<PlayerSwitchRF>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(ps.ActivePlayer.GetComponent<PlayerFollowRF>() !=null)
            pf = ps.ActivePlayer.GetComponent<PlayerFollowRF>();
        CameraFollow();
        GlitchCam();
    }

    private void CameraFollow()
    {
        Vector3 point = Camera.main.WorldToViewportPoint(pf.FollowPoint);
        Vector3 delta = pf.FollowPoint - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.4f, point.z)); //(new Vector3(0.5, 0.5, point.z));
        Vector3 destination = transform.position + delta;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        cameraScale = pf.CameraScale;
        if (cam.orthographicSize > cameraScale+0.1f)
        {
            cam.orthographicSize -= Time.deltaTime * scaleSpeed;
        }
        else if (cam.orthographicSize < cameraScale-0.1f)
        {
            cam.orthographicSize += Time.deltaTime * scaleSpeed;
        }
    }

    private void GlitchCam()
    {
        if (ps.ActivePlayer.GetComponent<PlayerGlitchRF>().WhatGlitchState() == "glitching")
        {
            timer += Time.deltaTime;
            ag.scanLineJitter = ac.Evaluate(timer/0.2f)*0.01f;
            ag.verticalJump = 0.01f;
            ag.colorDrift = ac.Evaluate(timer / 0.2f) * 0.02f;
        }
        else
        {
            timer = 0;
            ag.scanLineJitter =0;
            ag.verticalJump =0;
            ag.colorDrift =0;
        }
    }

}
