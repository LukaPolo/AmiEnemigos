using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAttacks : MonoBehaviour
{
    //Para destruir las balas al llegar a los limites
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "balas")
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }
}
