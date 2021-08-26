using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainCameraController : MonoBehaviour
{
    public GameObject sphere;
    public Vector3 offset;
    public TextMeshProUGUI instructions;

    void Start()
    {
        //Check offset from sphere
        offset = transform.position - sphere.transform.position;
        
    }

    //Called from ZoomIn button
    public void ZoomInOffset()
    {
        offset += new Vector3(0, 0, 2);
    }

    //Called from ZoomOut button
    public void ZoomOutOffset()
    {
        offset += new Vector3(0, 0, -2);
    }

    //Called from RotateLeft button
    public void RotateL()
    {
        Vector3 eulers = this.transform.rotation.eulerAngles;
        Debug.Log("Camera touch");
        eulers += new Vector3(0, -90, 0);
        transform.eulerAngles = eulers;
    }

    //Called from RotateRight button
    public void RotateR()
    {
        Vector3 eulers = this.transform.rotation.eulerAngles;
        Debug.Log("Camera touch");
        eulers += new Vector3(0, 90, 0);
        transform.eulerAngles = eulers;
    }

    //Keep the position of the camera w.r.t. the sphere
    void LateUpdate()
    {
        transform.position = sphere.transform.position + offset;
    }
}
