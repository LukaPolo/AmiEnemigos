using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public static bool impacto = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        disparo();
    }
    public void disparo()
    {
        Destroy(gameObject, 1.3f);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            impacto = true;  //impacta en mi personaje para bajarle vida          
        }
    }
    
    
}
