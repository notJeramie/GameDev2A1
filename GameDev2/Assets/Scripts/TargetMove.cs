using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    public float moveDistance = 500f;
    // Start is called before the first frame update
    void Start()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Move()
    {
        for (int i = 0; i < moveDistance; i++)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSecondsRealtime(3f);

        Move();

        //for (int i = 0; i < moveDistance; i++)
        //{
        //    transform.Translate(Vector3.forward * Time.deltaTime);
        //    yield return null;
        //}
    }
}
