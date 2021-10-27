using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rigidBody;

    void Start()
    {
        rigidBody.AddForce(transform.forward * speed);
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Target target = collision.gameObject.GetComponent<Target>();
            if (target != null)
            {
                target.OnHit();
                //Destroy(collision.gameObject, 1f);
                //Destroy(this.gameObject);
            }
        }
    }
}
