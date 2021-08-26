using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour
{
    public GameObject sphere;
    public Slider slider;
    public Button button;
    public SphereController sc;
    public Transform spawn;

    private Rigidbody rb;
    private float rot;
    private float speed = 6;
    private Vector3 eulers;

    // Start is called before the first frame update
    void Start()
    {
        //Slider and shoot button are inactive at the start
        slider.gameObject.SetActive(false);
        button.gameObject.SetActive(false);

        rb = sphere.GetComponent<Rigidbody>();
        button.onClick.AddListener(ShootBall);
        sc = GameObject.FindGameObjectWithTag("SphereController").GetComponent<SphereController>();
    }

    void Update()
    {
        //Rotate using values of the slider
        rot = slider.value;
        eulers = new Vector3(0, 0, 135 + rot);
        transform.eulerAngles = eulers;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //On collision with the sphere
        if (collision.gameObject.name == "BallPlayer")
        {
            //slider and button are activated
            slider.gameObject.SetActive(true);
            button.gameObject.SetActive(true);

            //sphere's position is fixed
            sphere.transform.position = new Vector3(-7.50f, 4, 0);
            rb.isKinematic = true;
        }
    }

    void ShootBall()
    {
        //Sphere movement
        rb.isKinematic = false;
        Vector3 movement = eulers;
        eulers.Normalize();
        rb.velocity = -spawn.up * speed;
        sc.originalPosition = new Vector3(-1.50f, 1.5f, 0);

        //Slider and button are disabled
        slider.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
    }

}