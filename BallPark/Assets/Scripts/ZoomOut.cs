using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{
    public Camera cam1;
    MainCameraController mc;

    private void Start()
    {
        mc = cam1.GetComponent<MainCameraController>();
    }

    public void Zoom()
    {

        mc.ZoomOutOffset();
    }
}
