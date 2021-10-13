using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{
    public Projectile projectilePrefab;
    public Transform firingPoint;
    public LayerMask targetLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            /*Projectile newProjectile;
            newProjectile = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
            Destroy(newProjectile.gameObject, 5f);*/

            RaycastHit hitInfo;
            if(Physics.Raycast(firingPoint.position, firingPoint.forward, out hitInfo, 1000f, targetLayer))
            {

                Target target = hitInfo.collider.GetComponent<Target>();
                if (target != null)
                {
                    target.OnHit();
                }

                TriggerPad2 sphereTrigger = hitInfo.collider.GetComponent<TriggerPad2>();
                if (sphereTrigger != null && sphereTrigger.inTrigger)
                //if (hitInfo.collider.gameObject.name == ("Sphere"))
                {
                    Debug.Log("it works");
                    sphereTrigger.shoot = true;
                }


                Debug.Log("hit" + hitInfo.collider.gameObject.name);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(firingPoint.position, firingPoint.forward, out hitInfo, 1000f, targetLayer))
            {
                TriggerPad2 sphereTrigger = hitInfo.collider.GetComponent<TriggerPad2>();
                if (sphereTrigger != null && sphereTrigger.inTrigger)
                //if (hitInfo.collider.gameObject.name == ("Sphere"))
                {
                    Debug.Log("E");
                    sphereTrigger.ePressed = true;
                }
            }
        }
    }
}
