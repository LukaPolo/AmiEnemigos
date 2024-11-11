using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foods : MonoBehaviour
{
    [SerializeField]
    private float debuff;//En el inspector se pone el decimal para hacer lento el personaje

    public float Debuff { get => debuff; set => debuff = value; }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            RataInteractions player = collision.GetComponent<RataInteractions>();
            player.HasFood = true;
            Destroy(gameObject);
        }
    }
}
