using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gato : MonoBehaviour
{
    public static float velX = 0;
    
   
    // Start is called before the first frame update
    void Start()
    {
        velX = 0.8f * Time.deltaTime;
        
    }
    // Update is called once per frame
    void Update()
    {
        movimiento();
    }
    public void movimiento()
    {
        if (plato.humor == false)
        {
            transform.Translate(velX, 0, 0);
            if (ColisionLimite.Limite == true)
            {
                velX = velX * -1;
                ColisionLimite.Limite = false;
            }
        }else
        {
            velX = 0;
            transform.Translate(velX, 0, 0);
        }
    }
   
   
}