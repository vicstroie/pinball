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
    

    

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        playerLives = 3;
        alive = false;
    }

    void SpawnBall()
    {
        ball = Instantiate(prefab, new Vector3(xpos, ypos, 0), Quaternion.identity);
        rb = ball.GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            
            if (!alive)
            {
                SpawnBall();
                alive = true;
                
            }
            else {
                //ball.transform.position = new Vector3(xpos, ypos, 0);
                Destroy(ball);
                SpawnBall();
            }

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




}
