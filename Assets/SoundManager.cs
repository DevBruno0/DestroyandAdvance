using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource SomMorte;
    public AudioSource SomFaca;
    public AudioSource SomMenu;
    public AudioSource SomJogo;
    public AudioSource SomBomba;
    public AudioSource SomLoja;
    public AudioSource SomVitoria;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TocarMorte() 
    {
        DesligarSons();
        SomMorte.Play();
    }

    public void TocarFaca()
    {
        SomFaca.Play();
    }

    public void TocarMenu()
    {
        DesligarSons();
        SomMenu.Play();
    }

    public void TocarJogo()
    {
        DesligarSons();
        SomJogo.Play();
    }

    public void TocarBomba()
    {
        SomBomba.Play();
    }
    public void TocaLoja()
    {
        DesligarSons();
        SomLoja.Play();
    }

    public void TocarVitoria()
    {
        DesligarSons();
        SomVitoria.Play();
    }
    void DesligarSons() 
    {
        SomJogo.Stop();
        SomMenu.Stop();
    }

    

}
