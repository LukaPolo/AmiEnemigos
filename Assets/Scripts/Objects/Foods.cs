using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foods : MonoBehaviour
{
    [SerializeField]
    private float debuff;//En el inspector se pone el decimal para hacer lento el personaje
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            ApplyDebuff();
            Destroy(gameObject);
        }
    }

    void ApplyDebuff()
    {
        //Una propiedad extra modificable de jugador = debuff;
        //ejemplo: player.multiplicadorDeVelocidad (normalmente es 1) = debuff;
        //Y así cuando, por ejemplo, en player el movimiento sea: rigid2d.velocity = input * velocidad * multiplicadorDeVelocidad  * Time.deltaTime;
        //para que se se aplique debidamente el debuff
        //Luego al dejar la comida, multiplicadorDeVelocidad debería ser de nuevo 1 para obtener velocidad normal 
    }
}
