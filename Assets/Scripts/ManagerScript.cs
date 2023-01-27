using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerScript : MonoBehaviour
{
    int playerScore = 0;
    int highScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    void Update()
    {
        highScoreText.text = highScore.ToString();
        scoreText.text = playerScore.ToString();

        if (Input.GetKeyDown("="))
        {
            playerScore += 5;
        }

        if (Input.GetKeyDown("-"))
        {
            playerScore -= 5;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadSavedData();
        }

        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("playerScore", highScore);
        }
    }

    public void LoadSavedData()
    {
        highScore = PlayerPrefs.GetInt("playerScore");
    }
}
