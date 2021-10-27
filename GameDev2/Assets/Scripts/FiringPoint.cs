using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{
    public Projectile projectilePrefab;
    public GameObject slingProjectile;
    public GameObject grenade;
    public Transform firingPoint;
    public Transform firingPoint2;
    public Transform grenadePoint;
    public LayerMask targetLayer;
    public float chargeSpeed = 1f;
    public float chargeTime;

    public GameObject[] gunTypes;
    public int gunCount;
    // Start is called before the first frame update
    void Start()
    {
        gunCount = 0;
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

        //Pistol
        if (Input.GetButtonDown("Fire1") && gunCount == 0)
        {
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


        //MachineGun
        if (Input.GetButton("Fire1") && gunCount == 1)
        {
            Projectile newProjectile;
            newProjectile = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
            Destroy(newProjectile.gameObject, 5f);
        }

        if (Input.GetButtonDown("Fire2") && gunCount == 1)
        {
            GameObject newProjectile;
            newProjectile = Instantiate(grenade, grenadePoint.position, grenadePoint.rotation);
            Destroy(newProjectile.gameObject, 5f);
        }


        //SlingShot
        if (Input.GetButton("Fire1") && gunCount == 2)
        {
            chargeSpeed = chargeSpeed + 10;
        }
        else
        if (chargeSpeed == chargeTime)
        {
            chargeSpeed = chargeTime;
        }
        else
        {
            chargeSpeed = 1f;
        }

        if(chargeSpeed >= chargeTime)
        {
            chargeSpeed = chargeTime;
        }

        if (Input.GetButtonUp("Fire1") && gunCount == 2)
        {
           // chargeSpeed = 1f;
        }

        if (Input.GetButtonUp("Fire1") && gunCount == 2 && chargeSpeed == chargeTime)
        {
            chargeSpeed = 1f;
            GameObject newProjectile2;
            newProjectile2 = Instantiate(slingProjectile, firingPoint2.position, firingPoint2.rotation);
            Destroy(newProjectile2.gameObject, 5f);
        }
        //Slingshot End


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
