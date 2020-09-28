using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Globalization;
using UnityEngine.UI;
using System.Diagnostics;

public class Level01Contoller : MonoBehaviour
{

    [SerializeField] Text _currentScoreTextView;

    int _currentScore;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseScore(5);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitLevel();
        }
    }

    public void IncreaseScore(int scoreIncrease)
    {
        _currentScore += scoreIncrease;
        //update score text display
        _currentScoreTextView.text =
            "Score: " + _currentScore.ToString();
    }

    public void ExitLevel()
    {

        int highScore = PlayerPrefs.GetInt("HighScore");
        if (_currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", _currentScore);
        }

        SceneManager.LoadScene("MainMenu");
    }
}
