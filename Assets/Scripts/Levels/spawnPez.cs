using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPez : MonoBehaviour
{
    private float tiempo = 1;
    private AudioSource aparece;
    public static int cantidad = 0;
    [SerializeField] Transform prefabComida;

    void Start()
    {
        aparece = GetComponent<AudioSource>();
        Invoke("Generar", 1f * Time.deltaTime);
    }
    void Update()
    {
        Generar();
    }
    void Generar()
    {    
        
        if (pez.comida == false && Movimiento.objetos == 0 && cantidad == 0)
         {
            aparece.Play();
            cantidad = 1; 
            Instantiate(prefabComida, transform.position, transform.rotation);
            Invoke("Generar", tiempo);
        }
          
    }
}
