using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad2 : MonoBehaviour
{
    public GameObject sphere;

    public float growSpeed = 0.025f;
    public float originalScale = 1.5f;

    public bool shoot;
    public bool inTrigger;
    public bool ePressed;

    private void Update()
    {
       if (!inTrigger && shoot)
       {
           shoot = false;
       }

       if (Input.GetButtonUp("Fire1"))
        {
            shoot = false;
        }

        if (!inTrigger && ePressed)
        {
            ePressed = false;
        }

        if (ePressed)
        {
            sphere.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            ePressed = false;
        }

        if (shoot)
        {
            sphere.transform.localScale += Vector3.one * growSpeed * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sphere.transform.localScale = Vector3.one * originalScale;
            sphere.GetComponent<MeshRenderer>().material.color = Color.blue;
            inTrigger = false;
        }
    }
}