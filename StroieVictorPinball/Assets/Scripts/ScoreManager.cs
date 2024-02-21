using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOver;
    public GameObject manager;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        score = manager.GetComponent<Spawner>().GetScore();
        scoreText.text = "Score: " + score.ToString();

        if(manager.GetComponent<Spawner>().gameOver)
        {
            gameOver.text = "Game Over! \n" + "Final Score: " + score.ToString() + "\n Press ENTER to Restart";
        } else
        {
            gameOver.text = "";
        }
    }
}
