using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SuccessScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    void Start()
    {
        GameStatus gameStatus = FindObjectOfType<GameStatus>();
        scoreText.text = gameStatus.ActualScore().ToString();
        gameStatus.ResetGameStatus();
    }
}
