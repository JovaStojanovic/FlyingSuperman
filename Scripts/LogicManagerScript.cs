using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManagerScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public SupermanScript script;
    [ContextMenu("Increase Score")]


    public void addScore(int scoreToAdd)
    {
        if (script.supermanIsAlive) { 
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void openMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        TransferHighScore.HighScore = playerScore;
    }
}
