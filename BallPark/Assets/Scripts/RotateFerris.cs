using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFerris : MonoBehaviour
{
    public GameObject parent;

    void Start()
    {
        parent = transform.parent.gameObject;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), 30 * Time.deltaTime);
        transform.RotateAround(parent.transform.position, new Vector3(0, 0, -1), 40 * Time.deltaTime);
    }
}
