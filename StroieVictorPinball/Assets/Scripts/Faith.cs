using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Faith : MonoBehaviour
{
    // Start is called before the first frame update
    public bool left;
    private bool add;
    private bool count;

    public GameObject manager;
    AudioSource aS;

    Rigidbody2D rb;
    SpriteRenderer sr;
    private int timer = 0;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        aS = GetComponent<AudioSource>();
        sr.enabled = false; 
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb = collision.GetComponent<Rigidbody2D>();
        add = true;
        manager.GetComponent<Spawner>().AddScore(500);
        aS.Play();
    }

    private void FixedUpdate()
    {
        if (add) {
            count = true;
            if (rb != null) {
                if (left)
                {
                    rb.AddForce(new Vector2(1, 1) * 15, ForceMode2D.Impulse);
                    add = false;
                }
                else
                {
                    rb.AddForce(new Vector2(-1, 1) * 15, ForceMode2D.Impulse);
                    add = false;
                }
            }
        }

        if(count)
        {
            sr.enabled = true;
            timer++;

            if(timer > 40)
            {
                timer = 0;
                count = false;
                sr.enabled = false;
            }
        }
        
      
    }
}
