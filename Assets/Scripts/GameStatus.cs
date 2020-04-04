using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Header("Config params")]
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [Header("State variables")]
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int actualLevel = 0;
    [SerializeField] int actualScore = 0;

    public int ActualLevel()
    {
        return actualLevel;
    }

    public int ActualScore()
    {
        return actualScore;
    }

    public void IncreaseActualLevel()
    {
        actualLevel += 1;
        actualScore = currentScore;
    }

    public void UpdateActualScore()
    {
        currentScore = actualScore;
        scoreText.text = currentScore.ToString();
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

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

}
