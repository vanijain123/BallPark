using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThirdPersonCamera : MonoBehaviour
{
    public GameObject sphere;
    private Vector3 offset;
    public TextMeshProUGUI instructions;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - sphere.transform.position;   
    }

    //Called by RotateLeft button
    public void RotateL()
    {
        Vector3 eulers = this.transform.rotation.eulerAngles;
        Debug.Log("Camera touch");
        eulers += new Vector3(0, -90, 0);
        transform.eulerAngles = eulers;
    }

    //Called by RotateRight button
    public void RotateR()
    {
        Vector3 eulers = this.transform.rotation.eulerAngles;
        Debug.Log("Camera touch");
        eulers += new Vector3(0, 90, 0);
        transform.eulerAngles = eulers;
    }

    void LateUpdate()
    {
        transform.position = sphere.transform.position + offset;
    }
}
