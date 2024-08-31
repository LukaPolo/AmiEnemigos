using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pez : MonoBehaviour
{
    public static bool comida = false;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {      
            comida = true;
            Destroy(gameObject, 1);     
    }
}
