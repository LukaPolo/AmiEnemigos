using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetDish : MonoBehaviour
{
    private AudioSource parar;
    public float vidmax, vidaActual;
    public Image barra;
    private bool DejarComida = false;
    private bool check;
    [SerializeField]
    private GameObject cat;
    // Start is called before the first frame update
    void Start()
    {
        vidmax = 10.0f;
        vidaActual = vidmax;
        parar = GetComponent<AudioSource>();
        check = false;

    }

    void Update()
    {
        almacenamiento();
        if (check)
        {
            cambiodeHumor();
        }

    }
    public void almacenamiento()
    {
        if (DejarComida == true)
        {
            vidaActual -= 1;
            barra.fillAmount = vidaActual / vidmax;
            spawnFood.generateFood = true;
            DejarComida = false;
        }

    }
    public void cambiodeHumor()
    {
        CatBehaviour Cat = cat.GetComponent<CatBehaviour>();

        if (vidaActual == 8)
        {
            //se va al medio y dispara directo
            if (check)
            {
                Cat.CatStatus = "phase2";
                Cat.ChangeStatus = true;
                check = false;
            }

        }
        else if (vidaActual == 6)
        {
            //embiste
            if (check)
            {
                Cat.CatStatus = "phase3";
                Cat.ChangeStatus = true;
                check = false;
            }
        }
        else if (vidaActual == 3)
        {
            //persigue
            Cat.CatStatus = "phase4";
            Cat.ChangeStatus = true;
            check = false;
        }
        else if (vidaActual == 0)
        {
            //se detiene
            Cat.CatStatus = "phase5";
            Cat.ChangeStatus = true;
            spawnFood.generateFood = false;
            parar.Pause();
            check = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {            
            RataInteractions player = collision.GetComponent<RataInteractions>();
            Movimiento movPlayer = collision.GetComponent<Movimiento>();
            if (player.HasFood)
            {
                movPlayer.MultVel = 1f;
                DejarComida = true;
                check = true;
                player.HasFood = false;
            }           
        }
    }
}
