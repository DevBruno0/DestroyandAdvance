using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    private bool escudoAtivo = false;
    public float duracaoEscudo = 5f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            AtivarEscudo();
        }
    }

    void AtivarEscudo()
    {
        if (!escudoAtivo)
        {
            escudoAtivo = true;
            StartCoroutine(DesativarEscudoAposTempo(duracaoEscudo));
            Debug.Log("Escudo Ativado");
        }
    }

    IEnumerator DesativarEscudoAposTempo(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        escudoAtivo = false;
        Debug.Log("Escudo Desativado");
    }

    public bool EstaAtivo()
    {
        return escudoAtivo;
    }

    void OnTriggerEnter(Collider other)
    {
        if (escudoAtivo && other.CompareTag("Knife"))
        {
            // Impedir que a "Knife" cause dano à "Bomba"
            // Você pode adicionar aqui qualquer ação que desejar, como destruir a "Knife" ou desativá-la.
            Debug.Log("Escudo protegeu a Knife!");
        }
    }
}
