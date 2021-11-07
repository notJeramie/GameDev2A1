using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{
    public GameObject manager;

    public bool time;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (time)
        //{
        //    timer += Time.deltaTime;
        //}
        //
        //if (timer >= 2f)
        //{
        //    timer = 0;
        //    time = false;
        //    manager.GetComponent<CardManager>().played = false;
        //}
    }

    private void OnMouseDown()
    {
        if (manager.GetComponent<CardManager>().played && !time)
        {
            manager.GetComponent<CardManager>().turnEnd = true;
            time = true;
            //manager.GetComponent<CardManager>().played = false;
        }
        else
        if(!time)
        {
            Debug.Log("You must play a card!");
        }

    }

    private void OnMouseUp()
    {
       // manager.GetComponent<CardManager>().played = false;
    }
}
