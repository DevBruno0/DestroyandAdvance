using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Knife : MonoBehaviour
{

    public bool isCutting = false;
    Camera mainCamera;

    public Vector3 distance;
    [SerializeField] float minVelocityCut = 0.001f;
    CircleCollider2D knifeCollider;
    TrailRenderer trail;

    GameController GJ;

    //VIDA
    [SerializeField] public int vida = 10;

    //BARRA DE HP
    private Image BarraHp;

    Vector3 currentMousePosition;
    Vector3 lastMousePosition;
    Vector3 mouseDelta;
    float mouseVelocity;

    [SerializeField] public GameObject TelaMorte;

    private void Awake()
    {
        trail = GetComponentInChildren<TrailRenderer>();
        knifeCollider = GetComponent<CircleCollider2D>();
        mainCamera = Camera.main;
    }
    void Start()
    {
        BarraHp = GameObject.FindGameObjectWithTag("hp_barra").GetComponent<Image>();
        GJ = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }
        if (isCutting)
        {
            IsCutting();
        }*/

        if (Input.GetMouseButton(0))
        {

            currentMousePosition = Input.mousePosition;

            mouseDelta = currentMousePosition - lastMousePosition;

            mouseVelocity = mouseDelta.magnitude / Time.deltaTime;

            lastMousePosition = currentMousePosition;

            if (mouseVelocity >= minVelocityCut)
            {
                StartCutting();
                knifeCollider.enabled = true;
            }
            else
            {
                StopCutting();
            }

        }
        else 
        {
            lastMousePosition = currentMousePosition;
            StopCutting();
            transform.position = currentMousePosition;
        }
    }

    private void LateUpdate()
    {

    }

    void StartCutting()
    {
        Vector3 newPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0;
        transform.position = newPos;
        isCutting = true;
        trail.enabled = true;
        GJ.soundManager.TocarFaca();

    }
    void StopCutting()
    {
        isCutting = false;
        trail.enabled = false;
    }
    /*void IsCutting()
    {
        Vector3 newPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0;
        

        distance = newPos - transform.position;
        float velocity = distance.magnitude * Time.deltaTime;

        if (velocity > minVelocityCut)
        {
            knifeCollider.enabled = true;
        }
        else
        {
            knifeCollider.enabled = false;
        }

        transform.position = newPos;
    }*/

    //VERIFICAR DANO

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.gameObject.tag == "Inimigo")
        {
            PerderHP();

            
        }
    }
    
    public void PerderHP()
    {
        vida--;
        int vida_parabarra = vida * 20;
        //BarraHp.rectTransform.sizeDelta = new Vector3(vida_parabarra, 100);
        BarraHp.fillAmount = vida * 0.33f;
        if (vida <= 0)
        {
            Morte();

        }
    }

    void Morte()
    {

        TelaMorte.SetActive(true);
        GJ.soundManager.TocarMorte();
        GJ.SalvarNoBanco();
        GJ.Pause();

    }
}
