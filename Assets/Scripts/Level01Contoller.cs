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

    public static bool _gameIsPaused = false;
    public GameObject _pauseMenuUI;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseScore(5);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
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

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _gameIsPaused = false;
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPaused = true;
    }

    public void QuitGame()
    {
        ExitLevel();
    }
}
