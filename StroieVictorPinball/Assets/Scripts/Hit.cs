using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    // Start is called before the first frame update

    public KeyCode hitcode;
    private Rigidbody2D _rb;
    public float thrust;
    private bool move;
    public bool left;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    private void Update()
    {

        if (left)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                move = true;

            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                move = false;
            }
        } else  {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                move = true;

            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                move = false;
            }
        }
    }

    void FixedUpdate()
    {
        if(move)
        {
            if(left) { 
                _rb.AddTorque(thrust, ForceMode2D.Impulse); 
            }
            else
            {
                _rb.AddTorque(-thrust, ForceMode2D.Impulse);
            }

            //Debug.Log("hit");
        }
    }
}
