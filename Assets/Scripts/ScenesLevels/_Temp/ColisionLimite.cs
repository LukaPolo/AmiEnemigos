using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionLimite : MonoBehaviour
{
    public static bool Limite = false;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {  
            Limite = true;
        }
       
    }
    
}
