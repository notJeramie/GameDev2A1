using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{
    public Projectile projectilePrefab;
    public Projectile SlingProjectile;
    public Transform firingPoint;
    public LayerMask targetLayer;

    public GameObject[] gunTypes;
    public int gunCount;
    // Start is called before the first frame update
    void Start()
    {
        gunCount = gunTypes.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //Pistol
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gunCount = 0;
        }

        //Machine
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gunCount = 1;
        }

        //Slingshot
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gunCount = 2;
        }

        if (Input.GetButtonDown("Fire1") && gunCount == 0)
        {
            //Projectile newProjectile;
            //newProjectile = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
            //Destroy(newProjectile.gameObject, 5f);

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
                    sphereTrigger.shoot = true;
                }


                Debug.Log("hit" + hitInfo.collider.gameObject.name);
            }

            
        }

        if (Input.GetButtonDown("Fire1") && gunCount == 1)
        {
            Projectile newProjectile;
            newProjectile = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
            Destroy(newProjectile.gameObject, 5f);
        }

        if (Input.GetButtonDown("Fire1") && gunCount == 2)
        {
            Projectile newProjectile;
            newProjectile = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
            Destroy(newProjectile.gameObject, 5f);
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
                    sphereTrigger.ePressed = true;
                }
            }
        }
    }
}
