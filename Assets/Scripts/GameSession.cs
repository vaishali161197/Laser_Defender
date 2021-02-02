using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int Score = 0;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
       if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);

        }
       else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return Score;
    }

    public void AddToScore(int ScoreValue)
    {
        Score += ScoreValue;
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
