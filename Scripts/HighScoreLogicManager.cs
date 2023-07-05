using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreLogicManager : MonoBehaviour
{
    
    public Text highScoreText;
    public int score = 0;
    private void Start()
    {
        highScoreText.text = GetHighScore().ToString();
    }

    private void Update()
    {   
        score = TransferHighScore.HighScore;
        if (score > GetHighScore())
        {
            PlayerPrefs.SetInt("Highscore", score);
            highScoreText.text = score.ToString();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("Highscore");
        return i;
    }
}
