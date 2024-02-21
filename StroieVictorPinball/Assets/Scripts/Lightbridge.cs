using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Lightbridge : MonoBehaviour
{

    public GameObject lightBridge;
    public GameObject manager;
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
            if (timer > 240)
            {
                lightBridge.SetActive(false);
                startTimer = false;
                timer = 0;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lightBridge.SetActive(true);
        startTimer = true;
        manager.GetComponent<Spawner>().AddScore(600);
    }
}
