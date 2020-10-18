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
    
    [SerializeField] Text _currentTimeTextView;
    [SerializeField] AudioSource _winSound;

    public int _currentTime = 30;

    public bool _takingAway = false;

    public static bool _gameIsPaused = false;
    public GameObject _pauseMenuUI;
    public GameObject _winScreenUI;

    void Start()
    {
        _currentTimeTextView.text = "00:" + _currentTime;
    }

    void Update()
    {

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

        if (_takingAway == false && _currentTime > 0)
        {
            StartCoroutine(TimerTake());
        }

        if (_currentTime <= 0)
        {
            Win();
        }
    }

    IEnumerator TimerTake()
    {
        _takingAway = true;
        yield return new WaitForSeconds(1);
        _currentTime -= 1;
        if (_currentTime < 10)
        {
            _currentTimeTextView.text = "00:0" + _currentTime;
        }
        else
        {
            _currentTimeTextView.text = "00:" + _currentTime;
        }
        _takingAway = false;
    }

    public void ExitLevel()
    {

        int highScore = PlayerPrefs.GetInt("HighScore");
        if (_currentTime > highScore)
        {
            PlayerPrefs.SetInt("HighScore", _currentTime);
        }

        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        SceneManager.LoadScene("Level01");
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

    public void Win()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _winScreenUI.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPaused = true;
    }

    public void ResetLevel()
    {
        Retry();
    }

    public void QuitGame()
    {
        ExitLevel();
    }
}
