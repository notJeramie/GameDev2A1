using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatteling : MonoBehaviour
{
    public float spinSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetButton("Fire1"))
        {
            transform.Rotate(new Vector3(0f, 0f, 1f * spinSpeed));
        }
    }
}
