using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeGel : MonoBehaviour
{

    Rigidbody2D rb;
    float vertVelocity = 0f;
    private bool speedUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb = collision.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //vertVelocity = rb.velocity.y;
        if(speedUp) {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 1.9f);
        }
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        speedUp = true;
    }

    private void OnTriggerExit(Collider other)
    {
        speedUp = false;
    }
}
