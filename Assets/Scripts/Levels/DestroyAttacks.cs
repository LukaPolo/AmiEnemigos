using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAttacks : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "balas")
        {
            Destroy(collision.transform.gameObject);
        }
    }
}
