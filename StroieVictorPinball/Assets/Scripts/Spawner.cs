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
    public bool open = true;
    private bool canCharge = false;
    public float charge;

    private bool count = false;
    private bool launch = false;

    Rigidbody2D rb;
    AudioSource aS;

    public GameObject lifePrefab;
    private GameObject lone;
    private GameObject ltwo;
    public GameObject launcher;
    public Transform launcherPos;
    public float launcherXpos;

    public bool gameOver;


    void SpawnBall()
    {
        ball = Instantiate(prefab, new Vector3(xpos, ypos, -10), Quaternion.identity);
        rb = ball.GetComponent<Rigidbody2D>();
        playerLives -= 1;
        Debug.Log(playerLives.ToString());
        canCharge = true;
        open = true;
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

        lone = Instantiate(lifePrefab, new Vector3(23, -20, 0), Quaternion.identity);
        ltwo = Instantiate(lifePrefab, new Vector3(23, -23, 0), Quaternion.identity);

        launcherPos = launcher.GetComponent<Transform>();
        launcherXpos = launcherPos.position.x;
        aS = GetComponent<AudioSource>();
    }





    // Update is called once per frame
    void Update()
    {

        if (ball != null) { 
            if (ball.GetComponent<Transform>().position.y < -50 && !gameOver) {

                if (playerLives > 0) {
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
        }

        
        //Emergency Respawn
        if(!gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            ball.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            ball.GetComponent<Transform>().position = new Vector3(xpos, ypos, -10);
            canCharge = true;
            

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
            lone.SetActive(false);
        }
        if (playerLives == 0)
        {
            ltwo.SetActive(false);
        }

        if (ball.GetComponent<Transform>().position.y < -30 && playerLives == 0) {
            gameOver = true;
        }

        if(gameOver && Input.GetKey(KeyCode.Return))
        {
            Restart();
        }
    }

    private void FixedUpdate()
    {
        if (count && charge < 150) {
            charge += 1f; 
        }

        if (charge == 0)
        {
            launcherPos.position = new Vector3(launcherXpos, -23.73f, 0);
        }
        else if (charge < 30)
        {
            launcherPos.position = new Vector3(launcherXpos, -23.73f - 0.7433f, 0);
        }
        else if (charge < 60)
        {
            launcherPos.position = new Vector3(launcherXpos, -23.73f - (2 * 0.7433f), 0);
        }
        else if (charge < 90)
        {
            launcherPos.position = new Vector3(launcherXpos, -23.73f - (3 * 0.7433f), 0);
        }
        else if (charge < 120)
        {
            launcherPos.position = new Vector3(launcherXpos, -23.73f - (4 * 0.7433f), 0);
        }
        else if (charge < 150)
        {
            launcherPos.position = new Vector3(launcherXpos, -23.73f - (5 * 0.7433f), 0);
        }





        if (launch) {
            rb.AddForce(Vector2.up * charge/4, ForceMode2D.Impulse);
            Debug.Log(charge.ToString());
            canCharge = false;
            charge = 0;
            count = false;
            launch = false;
            aS.Play();
        }
    }

    private void Restart() {
        playerLives = 3;
        playerScore = 0;
        canCharge = true;
        gameOver = false;
        SpawnBall();
        lone = Instantiate(lifePrefab, new Vector3(23, -20, 0), Quaternion.identity);
        ltwo = Instantiate(lifePrefab, new Vector3(23, -23, 0), Quaternion.identity);
    }

    public void AddScore(int score) {

        playerScore += score;
    
    }

    public int GetScore() {
        return playerScore;
    }

    public void CloseDoor() {
        open = false;
    }




}
