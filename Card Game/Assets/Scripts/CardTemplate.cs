using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTemplate : MonoBehaviour
{
    //This script is being commented on so much so in the future i can refer to this to add more cards.
    //This template only goes up to 4 steps keep this in mind for cards that have more than 4 steps.
    //THIS SHOULD NOT BE IN THE GAME IF IT IS YOU HAVE DONE SOMETHING WRONG.
    //ALL ANIMATION OF THE CARDS SHOULDN'T BE DONE HERE OTHERWISE IT WILL BE TOO HARD TO CHANGE LATER DO THAT IN ANOTHER SCRIPT

    //These Variables are going to tell the mover where this card should be
    public int stepRow;
    public int stepCollum;

    //These get turned on when the step is complete
    public bool step1;
    public bool step2;
    public bool step3;
    public bool step4;

    //set this as the parent not the card sprite itself
    public GameObject me;

    void Start()
    {
        grimbo();
    }

    void Update()
    {
        //This is to set what base tile you have been placed on.
        if (me.GetComponent<CardMover>().cardOnBoard)
        {

            if (me.GetComponent<CardMover>().placedInOne)
            {
                stepCollum += 2;
                me.GetComponent<CardMover>().cardInPlace = true;
            }
            else
            if (me.GetComponent<CardMover>().placedInTwo)
            {
                stepCollum += 3;
                me.GetComponent<CardMover>().cardInPlace = true;
            }
            else
            if (me.GetComponent<CardMover>().placedInThree)
            {
                stepCollum += 4;
                me.GetComponent<CardMover>().cardInPlace = true;
            }
            me.GetComponent<CardMover>().cardOnBoard = false;
            Debug.Log("test");
        }

        //Match the row and collum from this script to the Mover
        me.GetComponent<CardMover>().rowNum = stepRow;
        me.GetComponent<CardMover>().colNum = stepCollum;

        //Simply calling the functions depending on the step that you are up to.
        if (me.GetComponent<CardMover>().step == 1 && !step1)
        {
            step1 = true;
            StepOne();
        }
        if (me.GetComponent<CardMover>().step == 2 && !step2)
        {
            step2 = true;
            StepTwo();
        }
        if (me.GetComponent<CardMover>().step == 3 && !step3)
        {
            step3 = true;
            StepThree();
        }
        if (me.GetComponent<CardMover>().step == 4 && !step4)
        {
            step4 = true;
            StepFour();
        }

    }

    //What happens in each individual step, you will need to fill this in for every new card.
    public void StepOne()
    {

    }

    public void StepTwo()
    {

    }

    public void StepThree()
    {

    }

    public void StepFour()
    {

    }

    public void grimbo()
    {
        Debug.Log("fleepen");
    }
}
