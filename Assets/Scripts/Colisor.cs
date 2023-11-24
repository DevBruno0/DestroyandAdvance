using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisor : MonoBehaviour
{
    Knife player;


    void Start()
    {
        player = GameObject.FindAnyObjectByType<Knife>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fruits")
        {
            player.PerderHP();
        }
    }
}
