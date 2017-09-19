using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraFocusPoint : MonoBehaviour {
    [SerializeField]
    private Vector3 cameraFocusPos;
    public Vector3 CamerFocusPos
    {
        get
        {
            return cameraFocusPos;
        }
    }
    [SerializeField]
    private float cameraScale;
    public float CameraScale
    {
        get
        {
            return cameraScale;
        }
    }
}
