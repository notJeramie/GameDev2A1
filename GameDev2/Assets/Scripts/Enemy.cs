using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    OneHand,
    TwoHand,
    Archer,
   //---------
    COUNT
}

public class Enemy : MonoBehaviour
{
    float moveDistance = 500f;
    public EnemyType myType;

    public float health;

    // Start is called before the first frame update
    void Start()
    {
        // if (myType == EnemyType.OneHand)
        // {
        //     health = 100;
        // }
        //
        // if (myType == EnemyType.TwoHand)
        // {
        //     health = 150;
        // }
        // 
        // if (myType == EnemyType.Archer)
        // {
        //     health = 50;
        // }


        Setup();
    }

    public void Setup()
    {
        switch (myType)
        {
            case EnemyType.Archer:
                health = 50;
                break;
            case EnemyType.OneHand:
                health = 100;
                break;
            case EnemyType.TwoHand:
                health = 150;
                break;
            default:
                Debug.Log("Invalid Type Selected");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
     /*if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Move());
        }*/
    }

    IEnumerator Move()
    {
        for (int i = 0; i < moveDistance; i ++ )
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSecondsRealtime(3f);

        //for (int i = 0; i < moveDistance; i++)
        //{
        //    transform.Translate(Vector3.forward * Time.deltaTime);
        //    yield return null;
        //}
    }
}
