using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject manager;


    private void Start()
    {
        //manager = GameObject.FindAnyObjectByType<Manager>();
    }
    void Update()
    {
        
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //manager.GetComponent<Spawner>().alive = false;
        Destroy(this.gameObject);
    }
    */
}
