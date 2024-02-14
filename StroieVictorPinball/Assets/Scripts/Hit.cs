using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    // Start is called before the first frame update

    public KeyCode hitcode;
    private Rigidbody2D _rb;
    public float thrust;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.AddTorque(thrust, ForceMode2D.Impulse);
            Debug.Log("hit");
        
        }
    }
}
