using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRow : MonoBehaviour
{
    public bool one;
    public bool two;
    public bool three;

    public GameObject manager;

    public void OnMouseDown()
    {

    }
     public void OnMouseEnter()
    {
        if (one)
        {
            manager.GetComponent<CardManager>().BOneSelected = true;
        }
        else
        if (two)
        {
            manager.GetComponent<CardManager>().BTwoSelected = true;
        }
        else
        if (three)
        {
            manager.GetComponent<CardManager>().BThreeSelected = true;
        }
    }
    public void OnMouseExit()
    {
        if (one)
        {
            manager.GetComponent<CardManager>().BOneSelected = false;
        }
        else
        if (two)
        {
            manager.GetComponent<CardManager>().BTwoSelected = false;
        }
        else
        if (three)
        {
            manager.GetComponent<CardManager>().BThreeSelected = false;
        }
    }



}
