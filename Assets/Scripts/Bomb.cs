using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    
    Rigidbody2D rbBomb;
    [SerializeField] float force;

    [SerializeField] private GameController GJ;

    private void Awake()
    {
        rbBomb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        rbBomb.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Knife"))
        {
            GJ.soundManager.TocarBomba();
            Destroy(gameObject);
            //FindObjectOfType<GameController>().SetExplosion();
        }
    }
}
