using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plato : MonoBehaviour
{
    private AudioSource parar;
    public float vidmax, vidaActual;
    public static bool humor = false;
    public Image barra;
    public int almacenar= 0;
    private bool DejarComida = false;
    // Start is called before the first frame update
    void Start()
    {
        vidaActual = 10.0f;
        vidmax = 10.0f;
        parar = GetComponent <AudioSource>();
      
    }

    // Update is called once per frame
    void Update()
    {
        almacenamiento();
        cambiodeHumor();
    }
    public void almacenamiento()
    {
        if (DejarComida == true && Movimiento.objetos == 1)
            {         
                vidaActual -= 1; 
                barra.fillAmount = vidaActual / vidmax;    
                Movimiento.objetos = 0;
                spawnPez.cantidad = 0;
                DejarComida = false;           
            }
       
    }
    public void cambiodeHumor()
    {
        if(vidaActual == 0)
        {
            humor = true;
            parar.Pause();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            DejarComida = true;
        }
    }
}
