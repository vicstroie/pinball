using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{

    bool canCharge = false;
    GameObject ball;
    Rigidbody rb;
    float charge = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {

        if (canCharge) { 
            if (Input.GetKey(KeyCode.S))
            {
                charge += 1f;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                rb.AddForce(Vector3.up * charge);
                Debug.Log(charge);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        canCharge = true;
        ball = other.GetComponent<GameObject>();
        rb = other.GetComponent<Rigidbody>();
        Debug.Log("in!");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canCharge = false;  
    }
}
