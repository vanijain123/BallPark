using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), 20 * Time.deltaTime);
    }
}
