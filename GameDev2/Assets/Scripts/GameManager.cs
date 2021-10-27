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
public class GameManager : MonoBehaviour
{
    public Difficulty difficulty;
    public GameState gameState;
    public int scoreMultiplier;

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
        
    }
}
