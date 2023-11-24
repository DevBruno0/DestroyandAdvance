using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loja : MonoBehaviour
{
    public Text moedasText;
    Banco banco;
    public PararTempo pararTempo;
    public Text moedasinsuficienteText;

    GameController GJ;

    float timerLimpaTexto;

    public SoundManager soundManager;

    void Start()
    {

        banco = FindObjectOfType<Banco>();
        AtualizarMoedasText(); // Atualize o texto das moedas quando a cena iniciar
    }

    void Update()
    {
        LimparTexto();
        // Verifique se deseja atualizar o texto periodicamente (opcional)
    }

    void AtualizarMoedasText()
    {
        if (moedasText != null && banco != null)
        {
            moedasText.text = banco.MostrarMoedas().ToString();
        }
    }

    public void UpgradeTempo()
    {
        
        int precoUpgrade = 250; // DEFINIR O PRE�O DO UPGRADE

        if (pararTempo.VerificaCompra())
        {
            if (banco.GastarMoedas(precoUpgrade))
            {
                // Aumentar o tempo do parar tempo
                Debug.Log("Upgrade de tempo aplicado!");
                pararTempo.Upgrade();
                AtualizarMoedasText(); // Atualize o texto das moedas ap�s a compra
            }
            else
            {
                    // Mostrar mensagem ao jogador de que ele n�o tem moedas suficientes

                    moedasinsuficienteText.text = "Voc� n�o tem moedas suficientes.";
                    
                AtualizarMoedasText();
                LimparTexto();
            }

        }


    }
    public void LimparTexto()
    {
        if (moedasinsuficienteText.text.Length > 0) 
        { 
            if (timerLimpaTexto < 3)
            {
                timerLimpaTexto += Time.deltaTime;
                if (timerLimpaTexto >= 3)
                {
                    moedasinsuficienteText.text = "";
                    timerLimpaTexto = 2;
                }
            }
        }
        
    }
}
