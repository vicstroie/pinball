using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bc;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
        bc.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)) {
            sr.enabled = false;
            bc.isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bc.isTrigger = false;
        sr.enabled = true;
    }
}
