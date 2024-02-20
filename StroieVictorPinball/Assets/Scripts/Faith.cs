using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faith : MonoBehaviour
{
    // Start is called before the first frame update
    public bool left;

    Rigidbody2D rb;
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
        if(rb != null) {
            if (left)
            {
                rb.AddForce(new Vector2(1, 1) * 10, ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(new Vector2(-1, 1) * 10, ForceMode2D.Impulse);
            }
        }
        
      
    }
}
