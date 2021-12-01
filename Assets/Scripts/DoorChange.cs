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

    Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = redMat;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "DoctorChange1")
        {
            docDoor1.gameObject.transform.GetComponent<Renderer>().material = greenMat;
            docDoor2.gameObject.transform.GetComponent<Renderer>().material = greenMat;
            docDoor3.gameObject.transform.GetComponent<Renderer>().material = greenMat;

            balDoor1.gameObject.transform.GetComponent<Renderer>().material = greenMat;
            balDoor2.gameObject.transform.GetComponent<Renderer>().material = greenMat;
            balDoor3.gameObject.transform.GetComponent<Renderer>().material = greenMat;
        }

        if (other.name == "")
    }
}
