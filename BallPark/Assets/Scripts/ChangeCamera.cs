using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCamera : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public Button ZoomIn;
    public Button ZoomOut;
    public Button RotateL;
    public Button RotateR;

    private int counter = 0;

    public void Change()
    {
        if (counter < 3)
        {
            counter++;
        }
        else
        {
            counter = 0;
        }

        if (counter == 1)
        {
            //Disable all camera control buttons
            ZoomIn.gameObject.SetActive(false);
            ZoomOut.gameObject.SetActive(false);
            RotateL.gameObject.SetActive(false);
            RotateR.gameObject.SetActive(false);

            //On first click enable First Person Camera
            cam1.enabled = false;
            cam2.enabled = true;
            cam3.enabled = false;
        }
        else if (counter == 2)
        {
            //Disable ZoomIn ZoomOut buttons. Enable RotateLeft RotateRight buttons
            ZoomIn.gameObject.SetActive(false);
            ZoomOut.gameObject.SetActive(false);
            RotateL.gameObject.SetActive(true);
            RotateR.gameObject.SetActive(true);

            //On second click enable Third Person Camera
            cam1.enabled = false;
            cam2.enabled = false;
            cam3.enabled = true;
        }
        else
        {
            //Enable ZoomIn ZoomOut buttons
            ZoomIn.gameObject.SetActive(true);
            ZoomOut.gameObject.SetActive(true);

            //On third click enable Side View Camera
            cam1.enabled = true;
            cam2.enabled = false;
            cam3.enabled = false;
        }
    }
}
