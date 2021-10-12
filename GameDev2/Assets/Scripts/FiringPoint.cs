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


                Debug.Log("hit" + hitInfo.collider.gameObject.name);
            }
        }
    }
}
