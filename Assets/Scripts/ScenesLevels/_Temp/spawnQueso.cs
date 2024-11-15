using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnQueso : MonoBehaviour
{
    private AudioSource calma;
    private float tiempo = 1;
    private int cant = 1;
    [SerializeField] Transform prefabqueso;
    // Start is called before the first frame update
    void Start()
    {
        calma = GetComponent<AudioSource>();
        Invoke("Generar", 1f * Time.deltaTime);
    }
    void Update()
    {
        Generar();  
    }
    void Generar()
    {
        if (plato.humor == true && cant == 1) {
            calma.Play();
            Debug.Log("quesooooo");
            Instantiate(prefabqueso, transform.position, transform.rotation);
            Invoke("Generar", tiempo);
            plato.humor = false;
            cant = 0;
        }
    }
    
}
