using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRight : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    MainCameraController mc;
    ThirdPersonCamera tp;

    private void Start()
    {
        mc = cam1.GetComponent<MainCameraController>();
        tp = cam2.GetComponent<ThirdPersonCamera>();
    }

    public void Rotate()
    {
        if (cam1.enabled == true)
        {
            mc.RotateR();
        }
        if (cam2.enabled == true)
        {
            tp.RotateR();
        }
    }
}
