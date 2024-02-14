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
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)) {

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
        }
    }
}
