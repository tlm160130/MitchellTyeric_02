using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] Text _TimerTextView;

    void Start()
    {

        //int highScore = PlayerPrefs.GetInt("HighScore");
        //_highScoreTextView.text = highScore.ToString();
    }

    public void Reset()
    {
        //PlayerPrefs.DeleteKey("HighScore");
    }
}
