using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrangeGel : MonoBehaviour
{

    Rigidbody2D rb;
    public bool vert;
    private bool speedUp;
    AudioSource aS;
    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb = collision.GetComponent<Rigidbody2D>();
        speedUp = true;
        aS.Play();
    }

    private void FixedUpdate()
    {
        //vertVelocity = rb.velocity.y;
        if(speedUp) {
            if (vert)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 1.9f);
            } else
            {
                rb.velocity = new Vector2(rb.velocity.x * 1.9f, rb.velocity.y);
            }
        }
       
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        speedUp = false;
    }

    private void OnTriggerExit(Collider other)
    {
        speedUp = false;
    }
}
