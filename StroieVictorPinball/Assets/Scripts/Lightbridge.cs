using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightbridge : MonoBehaviour
{

    public GameObject lightBridge;
    private int timer = 0;
    private bool startTimer = false;


    private void Start()
    {
        lightBridge.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(startTimer)
        {
            timer++;
            if (timer > 120)
            {
                lightBridge.SetActive(false);
                startTimer = false;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lightBridge.SetActive(true);
        startTimer = true;
    }
}
