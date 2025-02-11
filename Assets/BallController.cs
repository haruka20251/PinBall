using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private float visiblPosZ = -6.5f;
    GameObject gameoverText;
    private int score;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameoverText = GameObject.Find("GameOverText");
        scoreText=GameObject.Find("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < visiblPosZ)
        {
            gameoverText.GetComponent<Text>().text="GameOver";
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SmallStarTag"))
        {
            score += 10;
            scoreText.text = "Score:" + score;
            
        }
        else if (collision.gameObject.CompareTag("LargeStarTag"))
        {
            score += 20;
            scoreText.text = "Score:" + score;
            
        }
        else if (collision.gameObject.CompareTag("SmallCloudTag"))
        {
            score += 30;
            scoreText.text = "Score:" + score;
            
        }
        else if (collision.gameObject.CompareTag("LargeCloudTag"))
        {
            score += 40;
            scoreText.text = "Score:" + score;
            
        }
    }

}
