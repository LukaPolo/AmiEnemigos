using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movBala : MonoBehaviour
{
    private AudioSource dismiauro;
    public float tiempoRandom= 0.4f;
    [SerializeField] Transform prefabDisparo = null;
    // Start is called before the first frame update
    void Start()
    {
        dismiauro = GetComponent<AudioSource>();
        Invoke("Generar", 1f * Time.deltaTime);
        
    }
    void Generar()
    {
        dismiauro.Play();
        Instantiate(prefabDisparo, transform.position, transform.rotation);
        Invoke("Generar", tiempoRandom);
    }
    public void disparo()
    {
        if (transform.position.y == 4.20f )
        {
            Destroy(gameObject, 0);
        }
    }
}
