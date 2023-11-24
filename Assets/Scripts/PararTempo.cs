using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PararTempo : MonoBehaviour
{
    private bool tempoLentoAtivo = false;
    public float escalaDeTempoLento = 0.8f;
    float ContadorTempo = 0;
    public float TempoMaximo = 0.5f;
    public float habilidadeUpgrade;
    public float upgrademax = 0.3f;

    bool chamarBotao = true;

    float ContarTempoBotao = 0;

    bool ativado = false;

    private GameObject objetoDesativar; // Referência ao objeto que deseja desativar.

    void Start()
    {
        //PlayerPrefs.SetFloat("Upgrade", 0);
        CarregarInfoHabilidade();
        objetoDesativar = GameObject.Find("HabilidadeSlow");
    }

    void Update()
    {
        if (tempoLentoAtivo)
        {
            ContadorTempo += Time.deltaTime;
            if (ContadorTempo >= TempoMaximo)
            {
                DesativarTempoLento();
                ContadorTempo = 0;
            }
        }
        if (chamarBotao == false)
        {
            ContarTempoBotao += Time.deltaTime;
            if (ContarTempoBotao > 5)
            {
                ContarTempoBotao = 0;
                chamarBotao = true;
                //GetComponent<MeshRenderer>().enabled = true;
            }
        }
        if (ativado)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.5f);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1,1);
        }
    }

    void AtivarTempoLento()
    {
        if (chamarBotao == true)
        {
            Time.timeScale = escalaDeTempoLento - habilidadeUpgrade;
            tempoLentoAtivo = true;
            //DesativarObjeto(); // Desativa o objeto quando a habilidade é ativada.

            chamarBotao = false;
            //GetComponent<MeshRenderer>().enabled = false;
        }

    }

    void DesativarTempoLento()
    {
        Time.timeScale = 1f;
        tempoLentoAtivo = false;

        AtivarObjeto(); // Ativa o objeto quando a habilidade é desativada.
    }

    void OnMouseDown()
    {
        if (ativado == false)
        {
            AtivarTempoLento();
            StartCoroutine("cooldownhabilidade");
        }
    }

    public void SalvarInfo()
    {
        PlayerPrefs.SetFloat("Upgrade", habilidadeUpgrade);
        PlayerPrefs.Save();
    }

    public void CarregarInfoHabilidade()
    {
        habilidadeUpgrade = PlayerPrefs.GetFloat("Upgrade");
    }

    IEnumerator cooldownhabilidade() {
        ativado = true;
        yield return new WaitForSeconds(10);
        ativado = false;
    }

    void DesativarObjeto()
    {
        gameObject.SetActive(false); // Desativa o objeto.
    }

    void AtivarObjeto()
    {
        gameObject.SetActive(true); // Ativa o objeto.
    }

    public void Upgrade()
    {
        if (habilidadeUpgrade < upgrademax)
        {
            CarregarInfoHabilidade();
            habilidadeUpgrade = habilidadeUpgrade + 0.1f;
            SalvarInfo();
        }

    }

    public bool VerificaCompra()
    {
        if (habilidadeUpgrade < upgrademax)
        {
            return true;
        }
        return false;
    }

}