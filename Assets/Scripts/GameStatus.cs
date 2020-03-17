﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    //Config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    //state variable
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        int countOfObjects = FindObjectsOfType<GameStatus>().Length;
        if( countOfObjects > 1)
        {
            gameObject.SetActive(false);
            Destroy( gameObject );
        }
        else
        {
            DontDestroyOnLoad( gameObject );
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGameStatus()
    {
        Destroy(gameObject);
    }
}
