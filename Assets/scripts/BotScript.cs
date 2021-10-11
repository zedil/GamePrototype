using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotScript : MonoBehaviour
{
    float botSpeed = 40;
    private Transform targetBoost;
    private Rigidbody2D rb;
    int score=0;
    public Text scoreText;


    static string highestScoreBot;
    static int highestScore = 0;
    int playerScore;
    string playerName;
    GameObject thePlayer;
    PlayerController playercontroller;
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        playercontroller = thePlayer.GetComponent<PlayerController>();
        playerName = playercontroller.tag;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        targetBoost = FindBoostTarget();
        playerScore = playercontroller.score;
    }

    private void FixedUpdate()
    {
        if(targetBoost != null)
        {
            Vector3 direction = (targetBoost.position - transform.position).normalized; 

            rb.MovePosition(transform.position + 0.1f *direction * botSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Boost"))
        {
            //Debug.Log("Collision");
            collision.gameObject.tag = "Untagged"; 
            Destroy(collision.gameObject);
            targetBoost = FindBoostTarget();
            ChangeScale();
        }
    }

    private void MakeScore()
    {
        score++;
        scoreText.text = score.ToString();

        //in case of tie, the one gets the highest score first wins the game
        if(score>highestScore)
        {
            highestScore = score;
            highestScoreBot = this.gameObject.tag;
        }
        
        if(playerScore>highestScore)
        {
            highestScore = playerScore;
            highestScoreBot = playerName;
        }

        //Save the highest score and its name to reach them in another scene
        PlayerPrefs.SetInt("highestScorePrefs", highestScore);
        PlayerPrefs.SetString("highestScoreBotPrefs", highestScoreBot);
        PlayerPrefs.Save();
    }

    public void ChangeScale()
    {
        Vector3 local = transform.localScale;
        transform.localScale += new Vector3(0.3f, 0.3f, 0f); //scale value increased as defined
        MakeScore(); 
    }

    public Transform FindBoostTarget() //This function returns the position of the closest boost
    {

        GameObject[] targetBoostArr = GameObject.FindGameObjectsWithTag("Boost"); //array of the target boosts
        float minDistance = 20.0f; 
        Transform closestBoost;

        //if no more boost left exit
        if(targetBoostArr.Length == 0)
        {
            return null;
        }

        closestBoost = targetBoostArr[0].transform; //initially the closest boost is the first one in the array 
        for(int i =1; i<targetBoostArr.Length; ++i) 
        {
            float distance = (targetBoostArr[i].transform.position - transform.position).sqrMagnitude; //calculate the distance between boost and bot

            if(distance < minDistance) 
            {
                closestBoost = targetBoostArr[i].transform;
                minDistance = distance; //set the new minDistance
                
            }
        }
        return closestBoost;
    }
}
