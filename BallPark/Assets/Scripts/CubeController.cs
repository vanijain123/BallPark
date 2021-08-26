using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeController : MonoBehaviour
{
    public GameObject cylinder;
    public Rigidbody cylinderrb;
    public GameObject obstacle;
    public GameObject obstacle1;

    private Rigidbody rigid;
    float speed = 6.0f;
    SphereController sphereController;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        obstacle = GameObject.Find("Obstacle");
        obstacle1 = GameObject.Find("Obstacle1");

        //Reference to SphereController script
        sphereController = GameObject.FindGameObjectWithTag("SphereController").GetComponent<SphereController>();
    }

    void Update()
    {
        //Cube movement
        Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x;

        if (dir.sqrMagnitude > 1)
        {
            dir.Normalize();
        }
        dir *= Time.deltaTime;
        transform.Translate(dir * speed);
        transform.rotation = Quaternion.identity;

        //Call SetTime() from SphereController script
        sphereController.SetTime();

        //Restart if health is 0 
        if (sphereController.healthCount == 0)
        {
            PlayerPrefs.SetString("health", sphereController.healthCount.ToString());
            PlayerPrefs.SetString("time", sphereController.time.ToString("F2"));
            SceneManager.LoadScene("LostScene");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //On Collision with cylinder
        cylinder = collision.gameObject;
        cylinderrb = cylinder.GetComponent<Rigidbody>();
        Debug.Log("On collision");
        if (cylinder.name == "LegsPlayer")
        {
            //Make cylinder parent of cube
            transform.SetParent(cylinder.transform, true);
            //Change cube's position w.r.t. cylinder
            transform.localPosition = new Vector3(0, 1, 0);

            //Change cube'properties so that it does not move
            rigid.isKinematic = true;
            GetComponent<Collider>().isTrigger = true;
            GetComponent<CubeController>().enabled = false;
            cylinderrb.isKinematic = false;
            cylinder.GetComponent<CylinderController>().enabled = true;

        }
    }

    //Falling obstacles
    private IEnumerator OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "ObstaclesTrigger")
        {
            obstacle.GetComponent<Rigidbody>().useGravity = true;

            yield return new WaitForSeconds(1);
            obstacle1.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    //Rings of fire
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Collided with the ring of fire");
        sphereController.SetHealth();
    }
}
