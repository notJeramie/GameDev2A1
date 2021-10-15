using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPicker : MonoBehaviour
{
    public bool pistol;
    public bool machine;
    public bool sling;

    public GameObject gun0;
    public GameObject gun1;
    public GameObject gun2;

    public float smallScale;
    public float origionalScale;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        gun0.transform.localScale = Vector3.one * origionalScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Reset();
            pistol = true;
            gun0.transform.localScale = Vector3.one * origionalScale;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Reset();
            machine = true;
            gun1.transform.localScale = Vector3.one * origionalScale;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Reset();
            sling = true;
            gun2.transform.localScale = Vector3.one * origionalScale;
        }
    }

    private void Reset()
    {
        pistol = false;
        machine = false;
        sling = false;
        gun0.transform.localScale = Vector3.one * smallScale;
        gun1.transform.localScale = Vector3.one * smallScale;
        gun2.transform.localScale = Vector3.one * smallScale;
    }
}
