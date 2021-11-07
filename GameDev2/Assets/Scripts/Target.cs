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
    public MeshRenderer meshRenderer;

    public TargetSize targetSize;
    public Difficulty difficulty;

    public bool isDead = false;

    public int health = 2;

    public float scaleFactor;
    public float targetScore = 1f;
    public float addTime = 5f;
    public float difficultyScale;




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

        DifficultyChange();

    }

    public void OnHit()
    {
        health = (health - 1);

        if (health <= 0 && !isDead)
        {
            GameManager.instance.score = (GameManager.instance.score + targetScore);
            GameManager.instance.timeLeft = (GameManager.instance.timeLeft + addTime);
            isDead = true;
        }

        if (health == 1)
        {
            meshRenderer.material.color = Color.yellow;

        }
    }

    public void OnKill()
    {

        meshRenderer.material.color = Color.red;
        Destroy(gameObject, 1f);
        TargetManager.instance.Remove(this);
    }

    public void DifficultyChange()
    {
        if (difficulty == Difficulty.Easy)
        {
            difficultyScale = 1.5f;
        }

        if (difficulty == Difficulty.Medium)
        {
            difficultyScale = 1;
        }

        if (difficulty == Difficulty.Hard)
        {
            difficultyScale = 0.5f;
        }
        transform.localScale = Vector3.one * scaleFactor;
        SetUp();
    }
    
}
