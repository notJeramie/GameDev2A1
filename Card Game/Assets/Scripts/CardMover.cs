using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMover : MonoBehaviour
{
    //These variables are to comunicate back and forth with the card script and get it to move into the first position.
    public bool placedInOne;
    public bool placedInTwo;
    public bool placedInThree;
    public bool cardOnBoard;
    public bool cardInPlace;

    private bool mouseOn;

    public string cardName;

    public float step;
    public float rowNum;
    public float colNum;

    public GameObject manager;

    public Transform card;

    public Transform front;
    public Transform back;
    public Transform token;

    public bool flip;
    public bool zoomedIn;
    public bool isSelected;
    public bool isPlayed;
    public bool endOfTurn;
    void Start()
    {
        //make the right card appear
        front.localScale = new Vector2(1, 1);
        back.localScale = new Vector2(0, 0);
        token.localScale = new Vector2(0, 0);
    }

    void Update()
    {
        //put the card in the right spot at the beginning of the turn
        if (cardInPlace)
        {
            Move();
            cardInPlace = false;
            //Move();
        }

        //lock the card in place and bring the pointers up
        if (isSelected && Input.GetMouseButtonDown(0) && !mouseOn )
        {
            zoomedIn = false;
            card.localScale = new Vector2(1, 1);
            card.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            Pointers();
        }

        //reset the pointers and stop the card from being large
        if (!zoomedIn && isSelected)
        {
            isSelected = false;
            Pointers();
        }

        //figure out what one of the three starting tiles the card will go in.
        if (Input.GetMouseButtonDown(0) && manager.GetComponent<CardManager>().BOneSelected && manager.GetComponent<CardManager>().played == false && isSelected)
        {
            CardPlayed();
            placedInOne = true;
            card.transform.position = new Vector2(transform.position.x, manager.GetComponent<CardManager>().baseRow.position.y);
            cardOnBoard = true;
            Debug.Log("beep");
        }

        if(Input.GetMouseButtonDown(0) && manager.GetComponent<CardManager>().BTwoSelected && manager.GetComponent<CardManager>().played == false && isSelected)
        {
            CardPlayed();
            placedInTwo = true;
            card.transform.position = new Vector2(transform.position.x, manager.GetComponent<CardManager>().baseRow.position.y);
            cardOnBoard = true;
        }

        if(Input.GetMouseButtonDown(0) && manager.GetComponent<CardManager>().BThreeSelected && manager.GetComponent<CardManager>().played == false && isSelected)
        {
            CardPlayed();
            placedInThree = true;          
            card.transform.position = new Vector2(transform.position.x, manager.GetComponent<CardManager>().baseRow.position.y);
            cardOnBoard = true;
        }

        //flip the card 
        if (Input.GetMouseButtonDown(1) && mouseOn)
        {
            Flip();
        }



        //if (manager.GetComponent<CardManager>().turnEnd && isPlayed)
        //{
        //    //manager.GetComponent<CardManager>().turnEnd = false;
        //    step += 1;
        //    Move();
        //    manager.GetComponent<CardManager>().turnEnd = false;
        //    endOfTurn = true;
        //    //manager.GetComponent<CardManager>().played = false;
        //}
        //
        //if(endOfTurn)
        //{
        //    //manager.GetComponent<CardManager>().played = false;
        //}
    }

    private void OnMouseUpAsButton()
    {
        if (manager.GetComponent<CardManager>().played == false)
        {
            isSelected = true;
            zoomedIn = true;
            Pointers();
        }

    }

    //flip the card back and forth. 
    private void Flip()
    {
            if (flip)
            {
                flip = false;
            }
            else
            if (!flip)
            {
                flip = true;
            }

            if (flip && !isPlayed)
            {
                front.localScale = new Vector2(0, 0);
                back.localScale = new Vector2(1, 1);
                token.localScale = new Vector2(0, 0);
            }

            if (!flip && !isPlayed)
            {
                front.localScale = new Vector2(1, 1);
                back.localScale = new Vector2(0, 0);
                token.localScale = new Vector2(0, 0);
            }
    }

    //move the card where it needs to go 
    private void Move()
    {
        //Row Controll
        if (rowNum <= 0)
        {
            //Card not in play so do nothing
        }
        if (rowNum == 1)
        {
            card.transform.position = new Vector2(transform.position.x, manager.GetComponent<CardManager>().rowOne.position.y);
            Debug.Log(cardName + " Row : " + rowNum);
        }
        if (rowNum == 2)
        {
            card.transform.position = new Vector2(transform.position.x, manager.GetComponent<CardManager>().rowTwo.position.y);
            Debug.Log(cardName + " Row : " + rowNum);
        }
        if (rowNum == 3)
        {
            card.transform.position = new Vector2(transform.position.x, manager.GetComponent<CardManager>().rowThree.position.y);
            Debug.Log(cardName + " Row : " + rowNum);
        }
        if (rowNum == 4)
        {
            card.transform.position = new Vector2(transform.position.x, manager.GetComponent<CardManager>().rowFour.position.y);
            Debug.Log(cardName + " Row : " + rowNum);
        }

        if (rowNum >= 6)
        {
            //kill the card and damage the enemy
        }


        //Collum Controll
        if (colNum ==  1)
        {
            card.transform.position = new Vector2(manager.GetComponent<CardManager>().colOne.position.x, transform.position.y);
            Debug.Log("Collum : " + colNum);
        }
        if (colNum == 2)
        {
            card.transform.position = new Vector2(manager.GetComponent<CardManager>().colTwo.position.x, transform.position.y);
            Debug.Log("Collum : " + colNum);
        }
        if (colNum == 3)
        {
            card.transform.position = new Vector2(manager.GetComponent<CardManager>().colThree.position.x, transform.position.y);
            Debug.Log("Collum : " + colNum);
        }
        if (colNum == 4)
        {
            card.transform.position = new Vector2(manager.GetComponent<CardManager>().colFour.position.x, transform.position.y);
            Debug.Log("Collum : " + colNum);
        }
        if (colNum == 5)
        {
            card.transform.position = new Vector2(manager.GetComponent<CardManager>().colFive.position.x, transform.position.y);
            Debug.Log("Collum : " + colNum);
        }

        manager.GetComponent<CardManager>().turnEnd = false;
        //manager.GetComponent<CardManager>().played = false;
    }

    private void OnMouseEnter()
    {
        mouseOn = true;
        if (!isSelected && !isPlayed)
        {
            card.localScale = new Vector2(2, 2);
            card.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }

        if (isPlayed)
        {
            front.localScale = new Vector2(0, 0);
            back.localScale = new Vector2(2, 2);
            token.localScale = new Vector2(0, 0);
        
        }
    }
    private void OnMouseExit()
    {
        if (!isSelected && !isPlayed)
        {    
            card.localScale = new Vector2(1, 1);
            card.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        
        if (isPlayed)
        {
            front.localScale = new Vector2(0, 0);
            back.localScale = new Vector2(0, 0);
            token.localScale = new Vector2(1, 1);
        }

        mouseOn = false;

    }

    //Tell the manager that the pointers need to be on screen. you need to fix it so they dont go away from one card to another.
    public void Pointers()
    {
        if (isSelected)
        {
            manager.GetComponent<CardManager>().pointerOnScreen = true;
        }
        else
        {
            manager.GetComponent<CardManager>().pointerOnScreen = false;
        }

    }

    public void CardPlayed()
    {
        isPlayed = true;
        manager.GetComponent<CardManager>().played = true;    
    }
}
