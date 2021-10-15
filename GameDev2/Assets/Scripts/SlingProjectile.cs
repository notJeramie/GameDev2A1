using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingProjectile : MonoBehaviour
{
    public GameObject cube;
    public float spinSpeed = 1f;
    public float chargeTime;
    public float growSpeed;
    public float origionalScale;
    public float shrinkScale;

    public bool freeze;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!freeze)
        {
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime * spinSpeed);
        }


        if (Input.GetButton("Fire1"))
        {
            spinSpeed = spinSpeed + 10;
        }
        else
        {
            spinSpeed = 1f;
        }

        if (spinSpeed >= chargeTime)
        {
            freeze = true;
        }

        if (Input.GetButtonUp("Fire1") && freeze)
        {
            freeze = false;
            spinSpeed = 1f;
            cube.transform.localScale = Vector3.one * shrinkScale;

        }

        if (transform.localScale.x >= origionalScale && transform.localScale.z >= origionalScale && transform.localScale.y >= origionalScale)
        {
            cube.transform.localScale = Vector3.one * origionalScale;
        }
        else
        {
            cube.transform.localScale += Vector3.one * growSpeed * Time.deltaTime;
        }
    }
}