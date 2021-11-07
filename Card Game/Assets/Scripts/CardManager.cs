using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public Transform baseRow;
    public Transform rowOne;
    public Transform rowTwo;
    public Transform rowThree;
    public Transform rowFour;

    public Transform colOne;
    public Transform colTwo;
    public Transform colThree;
    public Transform colFour;
    public Transform colFive;

    public Transform BOne;
    public Transform BTwo;
    public Transform BThree;
    public bool BOneSelected;
    public bool BTwoSelected;
    public bool BThreeSelected;
    public bool turnEnd;

    public Transform pointers;
    public bool pointerOnScreen;
    
    public bool played;

    public GameObject endTurn;
    void Start()
    {
        pointers.localScale = new Vector2(0, 0);
    }

    void Update()
    {
         if(pointerOnScreen)
        {
            pointers.localScale = new Vector2(1, 1);
        }
        else 
        {
            pointers.localScale = new Vector2(0, 0);
        }
    }
    

   
}
