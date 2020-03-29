using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGameStatus();
    }

    public void LoadActualLevel()
    {
        int offset = 2;
        SceneManager.LoadScene(offset + FindObjectOfType<GameStatus>().ActualLevel());
        FindObjectOfType<GameStatus>().UpdateActualScore();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameStatus gameStatus = FindObjectOfType<GameStatus>();
        if(gameStatus)
        {
            gameStatus.IncreaseActualLevel();
        }
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadFirstLevel()
    {
        FindObjectOfType<GameStatus>().ResetGameStatus();
        SceneManager.LoadScene(1);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
}
