using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public GameObject manager;
    public int score;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        manager.GetComponent<Spawner>().AddScore(score);
    }
}
