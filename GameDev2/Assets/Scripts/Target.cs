using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health = 2;

    public MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            OnKill();
        }
    }

    public void OnHit()
    {
        health = (health - 1);

        if (health == 1)
        {
            meshRenderer.material.color = Color.yellow;
        }
    }

    public void OnKill()
    {
        meshRenderer.material.color = Color.red;
        Destroy(gameObject, 1f);
    }
}
