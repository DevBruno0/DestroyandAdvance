using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] public bool jogoON = false;
    [SerializeField] public GameObject TelaMorte;
    [SerializeField] public GameObject TelaVitoria;
    [SerializeField] int score;
    [SerializeField] Text scoreText;

    [SerializeField] GameObject canetav;
    [SerializeField] GameObject borrachav;
    [SerializeField] GameObject apagadorv;

    public SoundManager soundManager;

    GameController GJ;

    Banco banco;

    Animator animator;

    Knife knife;
    Spawners spawners;

    [SerializeField] int Apagador;

    public Text txtApagador;

    [SerializeField] int Borracha;

    public Text txtBorracha;

    [SerializeField] int Caneta;
    public Text txtCaneta;


    private void Awake()
    {
        knife = FindObjectOfType<Knife>();
        spawners = FindObjectOfType<Spawners>();
        animator = GameObject.Find("Fade").GetComponent<Animator>();
        Pause();
        jogoON = false;
        Time.timeScale = 0;
    }
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        banco = GetComponent<Banco>();
        soundManager = GetComponent<SoundManager>();
    }

    public void SetScore(int amount)
    {
        score += amount + 1;
        scoreText.text = score.ToString();
    }

    void ClearGame()
    {
        Fruits[] fruits = FindObjectsOfType<Fruits>();

        foreach (Fruits fruit in fruits)
        {
            Destroy(fruit.gameObject);
        }
        Bomb[] bombs = FindObjectsOfType<Bomb>();

        foreach (Bomb bomb in bombs)
        {
            Destroy(bomb.gameObject);
        }
    }
    public void SetExplosion()
    {
        knife.enabled = false;
        knife.isCutting = false;
        spawners.enabled = false;
        ClearGame();
        animator.Play("Fade");
        Invoke("RestartGame", 1.0f);
        
    }

    void RestartGame()
    {
        score = 0;
        scoreText.text = score.ToString();
        SceneManager.LoadScene(0);
    }

    /*public void IniciarJogo()
    {
        Time.timeScale = 1f;
        jogoON = true;
    }

    public bool EstadoDoJogo()
    {
        Time.timeScale = 0f;
        return jogoON;
    } */

    public bool Estadojogo()
    {
        return jogoON;
    }
    public void Play()
    {
        jogoON = true;
        Time.timeScale = 1f;
        soundManager.TocarJogo();
        SetObjetivo();
       

    }
    public void Pause()
    {
        Time.timeScale = 0f;
        
    }
    public void Restart()
    {
        PersonagemMorreu();
        Time.timeScale = 1f;
        TelaMorte.SetActive(true);
        
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(0);
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void PersonagemMorreu()
    {
        TelaMorte.SetActive(true);
        jogoON = false;
        
        Debug.Log("Morri");
        Time.timeScale = 0;
        

    }

    public void AdquirirScore(int quantidade)
    {
        score += quantidade;

    }

    public void SalvarNoBanco()
    {
        banco.SalvarMoedas(score);
        Debug.Log(banco.MostrarMoedas());
    }

    public void SetObjetivo()
    {
        Apagador = Random.Range(1, 15);
        txtApagador.text = Apagador.ToString();

        Borracha = Random.Range(1, 15);
        txtBorracha.text = Borracha.ToString();

        Caneta = Random.Range(1, 15);
        txtCaneta.text = Caneta.ToString();
    }

    public void DecrementatObj(tipoObjeto tipo) 
    {
        switch (tipo)
        {
            case tipoObjeto.Apagador:
                if (Apagador > 0)
                {
                    Apagador--;
                    txtApagador.text = Apagador.ToString();
                    
                }
                if(Apagador == 0) 
                { 
                    apagadorv.SetActive(true);
                }
                break;
            case tipoObjeto.Caneta:
                if (Caneta > 0)
                {
                    Caneta--;
                    txtCaneta.text = Caneta.ToString();
                }
                if(Caneta == 0)
                {
                     canetav.SetActive(true);
                }
                break;
            case tipoObjeto.Borracha:
                if (Borracha > 0)
                {
                    Borracha--;
                    txtBorracha.text = Borracha.ToString();

                }
                if (Borracha == 0)
                {
                    borrachav.SetActive(true);
                }
                break;
            default:
                break;
        }

        Vitoria();
    }

    public void Vitoria()
    {
        if ( Apagador <= 0 && Borracha <= 0 && Caneta <= 0)
        {

            Time.timeScale = 0;
            jogoON = false;
            TelaVitoria.SetActive(true);
            soundManager.TocarVitoria();
            SalvarNoBanco();

        }
    }

    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}

    