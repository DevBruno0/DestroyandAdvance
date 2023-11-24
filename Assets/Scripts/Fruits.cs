using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fruits : MonoBehaviour
{
    Rigidbody2D rbfruit;
    [SerializeField] float force;

    [SerializeField] GameObject fruitWhole;
    [SerializeField] GameObject fruitCut;
    [SerializeField] int points = 2;
    [SerializeField] float newForce;

    ParticleSystem juice;

    Collider2D fruitCollider;

    public tipoObjeto tipo;

    GameController GJ;

    private void Awake()
    {
        juice = GetComponentInChildren<ParticleSystem>();
        fruitCollider = GetComponent<Collider2D>();
        if (fruitCollider== null)
        {
            fruitCollider = GetComponentInChildren<Collider2D>();
        }

        rbfruit = GetComponent<Rigidbody2D>();
        GJ = GameObject.FindObjectOfType<GameController>();
    }


    void Start()
    {
        rbfruit.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    void CuttingFruit()
    {
        GJ.SetScore(points);

        fruitWhole.SetActive(false);
        fruitCut.SetActive(true);
        fruitCollider.enabled = false;
        //juice.Play();

        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach ( Rigidbody rig in rigidbodies)
        {
            rig.velocity = rbfruit.velocity;
            Knife knife = FindObjectOfType<Knife>();
            rig.AddForceAtPosition(knife.distance * newForce, knife.transform.position, ForceMode.Impulse);

            Vector3 direcction = (knife.transform.position - transform.position).normalized;
            ///Quaternion newRotation = Quaternion.LookRotation(direcction);

            //fruitCut.transform.rotation = newRotation;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Knife"))
        {
            CuttingFruit();
            GJ.DecrementatObj(tipo);
        }

   
    }

}

public enum tipoObjeto
{
    Apagador,
    Caneta,
    Borracha,
}