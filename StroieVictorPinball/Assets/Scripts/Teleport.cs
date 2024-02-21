using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject exitPortal;
    public GameObject manager;
    private Rigidbody2D rb;
    private float xpos = 0;
    private float ypos = 0;

    AudioSource aS;

    private void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        xpos = exitPortal.GetComponent<Transform>().position.x;
        ypos = exitPortal.GetComponent<Transform>().position.y;


        collision.gameObject.GetComponent<Transform>().position = new Vector3(xpos, ypos, 0);
        rb = collision.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x/2, rb.velocity.y/2);

        manager.GetComponent<Spawner>().AddScore(300);
        
        aS.Play();
    }
}
