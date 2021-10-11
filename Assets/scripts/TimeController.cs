using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    public float gameDuration; //game duration in seconds
    float remainingGameTime; //remaining game time in seconds
    public Text TimerText;
    void Start()
    {
        //TimerText = gameObject.GetComponent<Text>();
        remainingGameTime = gameDuration; //at start remanining game time is equals to game duration
    }

    // Update is called once per frame
    void Update()
    {
        if(remainingGameTime>=0)
        {
            remainingGameTime -= Time.deltaTime;
            if (remainingGameTime <= 10)
            {
                //TimerText.color = Color.red;
                TimerText.GetComponent<Text>().color = Color.red;
            }
            int remainingGameTime_int = (int)(remainingGameTime);
            TimerText.text = remainingGameTime_int.ToString();
        }
        else
        {
            //when remaining game time equals to game duration end the game
            endGame();
        }

    }
    void endGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
