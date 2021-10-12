using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad : MonoBehaviour
{
    public GameObject sphere;   //The object we wish to change

    public float growSpeed = 0.025f;
    public float originalScale = 1.5f;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //change the spheres colour to green
            sphere.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Increas the spheres scale by 0.01 on all axis
            sphere.transform.localScale += Vector3.one * growSpeed * Time.deltaTime;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //set the spheres size back to 1
            //Change the spheres colour to yellow
            sphere.transform.localScale = Vector3.one * originalScale;
            sphere.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }
}

