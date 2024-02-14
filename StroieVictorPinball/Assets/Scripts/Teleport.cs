using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject exitPortal;
    private float xpos = 0;
    private float ypos = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        xpos = exitPortal.GetComponent<Transform>().position.x;
        ypos = exitPortal.GetComponent<Transform>().position.y;


        collision.gameObject.GetComponent<Transform>().position = new Vector3(xpos, ypos, 0);
    }
}
