using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerController : MonoBehaviour
{
    string winnerName;
    int winnerScore;
    public Text winnerText;
    void Start()
    {
        winnerScore = PlayerPrefs.GetInt("highestScorePrefs");
        winnerName = PlayerPrefs.GetString("highestScoreBotPrefs");
        winnerText.text = winnerName + " score: " + winnerScore.ToString();
        Debug.Log(winnerName);

    }
    void Update()
    {
        
    }
}
