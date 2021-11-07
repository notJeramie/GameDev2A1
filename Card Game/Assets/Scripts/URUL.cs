using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URUL : MonoBehaviour
{

    public int stepRow;
    public int stepCollum;

    public bool step1;
    public bool step2;
    public bool step3;
    public bool step4;

    public GameObject me;

    public bool onBoard;

    void Start()
    {

    }

    void Update()
    {

        if (me.GetComponent<CardMover>().cardOnBoard)
        {
            me.GetComponent<CardMover>().cardOnBoard = false;
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
        }

        me.GetComponent<CardMover>().rowNum = stepRow;
        me.GetComponent<CardMover>().colNum = stepCollum;

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

    public void StepOne()
    {
        stepRow += 1;
    }

    public void StepTwo()
    {
        stepRow += 1;
        stepCollum += 1;
    }

    public void StepThree()
    {
        stepRow += 1;   
    }

    public void StepFour()
    {
        stepRow += 1;
        stepCollum -= 1;
    }
}
