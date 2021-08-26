using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CylinderController : MonoBehaviour
{
    public Camera cam;

    private Rigidbody rigid;
    float speed = 6.0f;
    int jumpHeight = 5;
    SphereController sphereController;
    Vector3 dir;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        sphereController = GameObject.FindGameObjectWithTag("SphereController").GetComponent<SphereController>();
    }

    void Update()
    {
        //Set time elapsed
        sphereController.SetTime();

        //Check if health is 0, game is restarted
        if (sphereController.healthCount == 0)
        {
            PlayerPrefs.SetString("health", sphereController.healthCount.ToString());
            PlayerPrefs.SetString("time", sphereController.time.ToString("F2"));
            SceneManager.LoadScene("LostScene");
        }
    }

    //Using RayCast to make the player hop left or right
    private void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray;
        Vector3 vel = Vector3.zero;
        if (Input.GetMouseButtonDown(0))
        {
            
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(ray.origin, ray.direction);
                vel = ray.direction * speed;
                Debug.Log(vel.x);
                rigid.velocity = new Vector3(vel.x, jumpHeight, 0);
                transform.rotation = Quaternion.identity;
            }
        }
        
    }

    //Collision with rings of fire
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Collided with the ring of fire");
        sphereController.SetHealth();
    }

    //This trigger ends the game. Shares the health and time values with the next scene
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GameOverTrigger")
        {
            PlayerPrefs.SetString("health", sphereController.healthCount.ToString());
            PlayerPrefs.SetString("time", sphereController.time.ToString("F2"));
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
