using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour

{
    private GameObject ball;
    public GameObject prefab;
    public int xpos;
    public int ypos;
    private int playerScore;
    private int playerLives;
    public bool alive;
    private bool canCharge = false;
    public float charge;

    private bool count = false;
    private bool launch = false;

    Rigidbody2D rb;

    public GameObject lifePrefab;
    private GameObject lone;
    private GameObject ltwo;

    private bool gameOver;


    void SpawnBall()
    {
        ball = Instantiate(prefab, new Vector3(xpos, ypos, 0), Quaternion.identity);
        rb = ball.GetComponent<Rigidbody2D>();
        playerLives -= 1;
        Debug.Log(playerLives.ToString());
        canCharge = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        playerLives = 3;

        alive = false;
        SpawnBall();
        canCharge = true;
        gameOver = false;

        lone = Instantiate(lifePrefab, new Vector3(22, -25, 0), Quaternion.identity);
        ltwo = Instantiate(lifePrefab, new Vector3(22, -27, 0), Quaternion.identity);

    }

    



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ball.GetComponent<Transform>().position.y < -30) {
            
            if(playerLives > 0) {
                if (!alive)
                {
                    SpawnBall();
                    alive = true;

                }
                else
                {
                    //ball.transform.position = new Vector3(xpos, ypos, 0);
                    Destroy(ball);
                    SpawnBall();
                }
                
            }
            
        }

        if (canCharge)
        {


            if (Input.GetKey(KeyCode.DownArrow))
            {
                count = true;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                launch = true;
            }


        }

        if(playerLives == 1)
        {
            ltwo.SetActive(false);
        }
        if (playerLives == 0)
        {
            lone.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (count && charge < 75) {
            charge += 1f; 
        }

        if (launch) {
            rb.AddForce(Vector2.up * charge, ForceMode2D.Impulse);
            Debug.Log(charge.ToString());
            canCharge = false;
            charge = 0;
            count = false;
            launch = false;
        }
    }

    private void Restart() {
        playerLives = 3;
        playerScore = 0;
        canCharge = true;
        SpawnBall();
    }

    public void AddScore(int score) {

        playerScore += score;
    
    }




}
