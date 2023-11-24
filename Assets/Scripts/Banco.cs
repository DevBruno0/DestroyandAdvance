using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Banco : MonoBehaviour
{
    public int Moedas;

    public Text txtMoedas;


    void Start()
    {
        CarregarMoedas();
        txtMoedas.text = Moedas.ToString();
    }

    void Update()
    {

    }

    public void CarregarMoedas()
    {
        Moedas = PlayerPrefs.GetInt("Moedas");
    }

    public void SalvarMoedas(int Score)
    {
        int TotalMoedas = PlayerPrefs.GetInt("Moedas");
        TotalMoedas = Score + TotalMoedas;
        PlayerPrefs.SetInt("Moedas", TotalMoedas);
        PlayerPrefs.Save();
        CarregarMoedas();
    }

    public int MostrarMoedas()
    {
        int TotalMoedas = PlayerPrefs.GetInt("Moedas");
        return TotalMoedas;
    }


    public bool GastarMoedas(int Preco) 
    { 
        if (Moedas > Preco)
        {

            int TotalMoedas = Moedas - Preco;
            
            PlayerPrefs.SetInt("Moedas", TotalMoedas);
            PlayerPrefs.Save();
            CarregarMoedas();
            return true;
        }

        return false;
    }



}
