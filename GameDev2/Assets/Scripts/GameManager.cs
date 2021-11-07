using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Difficulty
{
    Easy,
    Medium,
    Hard,
    //--------
    COUNT
}

public enum GameState
{
    Start,
    Playing,
    Paused,
    GameOver,
    //---------
    COUNT
}
public class GameManager : Singleton<GameManager>
{
    public Difficulty difficulty;
    
    public GameState gameState;
   
    public float scoreMultiplier = 1.5f;
    public float score;
    public float timeLeft = 30f;
    

    public void AddScore(float amount)
    {
        score += (amount * scoreMultiplier);
    }

    public void AddTime(float amount)
    {
        timeLeft += amount;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Start;
        difficulty = Difficulty.Easy;

        SetUp();
    }

    void SetUp()
    {
        switch(difficulty)
        {
            case Difficulty.Easy:
                scoreMultiplier = 1;
                break;
            case Difficulty.Medium:
                scoreMultiplier = 2;
                break;
            case Difficulty.Hard:
                scoreMultiplier = 3;
                break;
            default:
                scoreMultiplier = 1;
                break;

        }
    }


    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(score);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            timeLeft = 30f;
        }

        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Alpha8))
        {
            difficulty = Difficulty.Easy;
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            difficulty = Difficulty.Medium;
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            difficulty = Difficulty.Hard;
        }
    }
}
