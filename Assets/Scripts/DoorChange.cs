using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorChange : MonoBehaviour
{
    public GameObject docDoor1;
    public GameObject docDoor2;
    public GameObject docDoor3;

    public GameObject balDoor1;
    public GameObject balDoor2;
    public GameObject balDoor3;

    public GameObject docNameplate;
    public GameObject balNameplate;

    //public Material greenMat;
    //public Material redMat;
    //public Material blueMat;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "DoctorDoor" && other.gameObject.name == "DoctorChange1")
    //    {
    //        Object.material = 
    //    }
    //}

    public Material redMat;
    public Material greenMat;
    public Material blueMat;

    Renderer rend;

    private void Start()
    {
        //rend = GetComponent<Renderer>();
        //rend.enabled = true;
        //rend.sharedMaterial = redMat;
        docDoor1.gameObject.GetComponent<Renderer>().material = blueMat;
        docDoor2.gameObject.GetComponent<Renderer>().material = blueMat;
        docDoor3.gameObject.GetComponent<Renderer>().material = blueMat;

        balDoor1.gameObject.GetComponent<Renderer>().material = blueMat;
        balDoor2.gameObject.GetComponent<Renderer>().material = blueMat;
        balDoor3.gameObject.GetComponent<Renderer>().material = blueMat;

        docNameplate.SetActive(false);
        balNameplate.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "DoctorChange1")
        {
            docDoor1.gameObject.GetComponent<Renderer>().material = greenMat;
            docDoor2.gameObject.GetComponent<Renderer>().material = greenMat;
            docDoor3.gameObject.GetComponent<Renderer>().material = greenMat;

            balDoor1.gameObject.GetComponent<Renderer>().material = redMat;
            balDoor2.gameObject.GetComponent<Renderer>().material = redMat;
            balDoor3.gameObject.GetComponent<Renderer>().material = redMat;

            docNameplate.SetActive(true);
            balNameplate.SetActive(false);
        }

        if (other.name == "BallerinaChange1")
        {
            docDoor1.gameObject.GetComponent<Renderer>().material = redMat;
            docDoor2.gameObject.GetComponent<Renderer>().material = redMat;
            docDoor3.gameObject.GetComponent<Renderer>().material = redMat;
            

            balDoor1.gameObject.GetComponent<Renderer>().material = greenMat;
            balDoor2.gameObject.GetComponent<Renderer>().material = greenMat;
            balDoor3.gameObject.GetComponent<Renderer>().material = greenMat;

            docNameplate.SetActive(false);
            balNameplate.SetActive(true);
        }
    }
}
