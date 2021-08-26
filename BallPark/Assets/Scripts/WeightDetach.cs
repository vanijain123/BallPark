using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightDetach : MonoBehaviour
{
    private GameObject SStrigger;
    private Vector3 screenPoint;
    private Vector3 offset;
    private bool movable;
    Renderer rend;
    private Rigidbody rigid;
    private float speed = 10;
    private int count;

    private void Start()
    {
        movable = false;
        rend = GetComponent<Renderer>();
        rigid = GetComponent<Rigidbody>();
        count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if weight can be moved or not
        movable = false;
        SStrigger = other.gameObject;
        if(SStrigger.name == "SeeSawTrigger")
        {
            //Make the weight stationary on coming in contact with the trigger
            rigid.isKinematic = true;
        }
    }

    private void Update()
    {
        if (movable == true)
        {
            //If weight is movable, move it to the right until it hits the trigger
            Vector3 dir = Vector3.zero;
            dir.x = Input.acceleration.x;

            if (dir.sqrMagnitude > 1)
            {
                dir.Normalize();
            }
            Vector3 movement = new Vector3(10, 0, 0);
            rigid.AddForce(movement * speed * Time.deltaTime);
        }
        
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "BallPlayer" && count == 0)
        {
            count = 1;
            transform.position = new Vector3(-3.19f, 1.25f, 0);
            movable = true;
            rend.material.SetColor("_Color", Color.red);
            rigid.isKinematic = false;
        }
    }
}
