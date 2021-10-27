using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetSize
{
    Big,
    Medium,
    Small,
    //-------
    COUNT
}

public class Target : MonoBehaviour
{
    public int health = 2;

    public MeshRenderer meshRenderer;

    public TargetSize targetSize;

    public float scaleFactor;



    // Start is called before the first frame update
    void Start()
    {
        SetUp();
        transform.localScale = Vector3.one * scaleFactor;
    }

    void SetUp()
    {
        switch (targetSize)
        {
            case TargetSize.Small:
                scaleFactor = 0.5f;
                break;
            case TargetSize.Medium:
                scaleFactor = 1f;
                break;
            case TargetSize.Big:
                scaleFactor = 1.5f;
                break;
            default:
                Debug.Log("Invalid Type Selected");
                break;
        }
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
