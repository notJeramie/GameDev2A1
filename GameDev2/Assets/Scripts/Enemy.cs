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

    public Animator anim;

    public float health;
    public float onHitScore = 10f;
    public float onKillSore  = 100f;

    // Start is called before the first frame update
    void Start()
    {
        if (myType == EnemyType.OneHand)
        {
            health = 100;
        }
        
        if (myType == EnemyType.TwoHand)
        {
            health = 150;
        }
        
        if (myType == EnemyType.Archer)
        {
            health = 50;
        }


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
     if (Input.GetKeyDown(KeyCode.H))
        {
            Hit();
        }

     if (health <= 0)
        {
            Die();
        }
    }


    public void Hit()
    {
        anim.SetTrigger("Hit");
        health = (health -= 10);
        GameManager.instance.AddScore(onHitScore);
    }

    public void Die()
    {
        anim.SetTrigger("Die");
        GameManager.instance.AddScore(onKillSore);

        StopAllCoroutines();
        Destroy(gameObject, 3f);
        

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
