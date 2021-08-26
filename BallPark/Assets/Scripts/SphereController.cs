using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SphereController : MonoBehaviour
{
    public int healthCount;
    public TextMeshProUGUI health;
    public TextMeshProUGUI timer;
    public Image DamageColor;
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public GameObject cube;
    public Rigidbody cuberb;
    public float time;
    public GameObject SStrigger;
    public Vector3 originalPosition;

    private Rigidbody rigid;
    float speed = 50.0f;
    private Color d_color;
    private GameObject weight;
    private Rigidbody weightrb;
    private MeshRenderer rend;

    void Start()
    {
        //Sphere Rigidbody
        rigid = GetComponent<Rigidbody>();

        //Setting health to 100
        healthCount = 100;
        //Setting time elapsed to 0
        time = 0;

        //Enable MainCamera 
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;

        //Setting position for respawning of the player
        originalPosition = new Vector3(-13.08f, 1.5f, 0f);

        //sphere Mesh Renderer so that we can change the color when player takes a hit
        rend = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        //Player movement
        Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x;
        
        if (dir.sqrMagnitude > 1)
        {
            dir.Normalize();
        }
        Vector3 movement = new Vector3(dir.x, 0, 0);
        rigid.AddForce(movement * speed * Time.deltaTime);

        //Setting Time elapsed
        SetTime();

        //Checking if health reaches 0, the game restarts by loading the scene
        if (healthCount == 0)
        {
            PlayerPrefs.SetString("health", healthCount.ToString());
            PlayerPrefs.SetString("time", time.ToString("F2"));
            SceneManager.LoadScene("LostScene");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //collision with cube
        cube = collision.gameObject;
        cuberb = cube.GetComponent<Rigidbody>();

        if (cube.name == "BodyPlayer")
        {
            //Make cube the parent of sphere
            transform.SetParent(cube.transform, true);

            //Change sphere's location w.r.t. the cube
            transform.localPosition = new Vector3(0, 1, 0);

            //Make sphere kinematic so it does not move with gyro
            rigid.isKinematic = true;
            GetComponent<Collider>().isTrigger = true;
            GetComponent<SphereController>().enabled = false;

            //Set cube's kinematic to flase, so that the cube can now move
            cuberb.isKinematic = false;
            cube.GetComponent<CubeController>().enabled = true;
            transform.localRotation= Quaternion.identity;
        }

        //collision with weight
        weight = collision.gameObject;
        weightrb = weight.GetComponent<Rigidbody>();
    }

    //Turning sphere red on taking damage
     public IEnumerator ShowDamage()
    {
        Color c = new Color(0.6909792f, 1, 0, 1);
        rend.material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(1);
        rend.material.SetColor("_Color", c);
    }

    //Reducing health on taking damage
    public void SetHealth()
    {
        healthCount -= 5;
        health.text = "Health: " + healthCount;
        //Start Coroutine 
        StartCoroutine(ShowDamage());
    }

    //Set time elapsed
    public void SetTime()
    {
        time = time + Time.deltaTime;
        timer.text = "Time Elapsed: " + time.ToString("F2") + " seconds";
    }

    private void OnTriggerEnter(Collider other)
    {
        SStrigger = other.gameObject;

        //If in contact wiht the floor
        if(SStrigger.name == "Floor")
        {
            transform.position = originalPosition;
            rigid.velocity = new Vector3(0, 0, 0);
            SetHealth();
        }

        //If in contact with the falling obstacles
        if(SStrigger.name == "Obstacle" || SStrigger.name == "Obstacle1")
        {
            Debug.Log("Hit by obstacle");
            SetHealth();
        }

        //If in contact wiht the Mid Platform
        if(SStrigger.name == "MidPlatform")
        {
            transform.position = new Vector3(-7.50f, 4, 0);
            SetHealth();
        }
    }

    //Collision with rings of fire
    private void OnParticleCollision(GameObject other)
    {
        SetHealth();
    }
}
