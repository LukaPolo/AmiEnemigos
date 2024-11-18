using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAnims : MonoBehaviour
{
    [SerializeField] private Transform rat;
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator FollowPlayer()
    {
        while (true)
        {
            Vector2 direction = (rat.position - transform.position).normalized;
            // Comparar la direccion en el eje X y el eje Y
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                // Movimiento hacia los lados
                if (direction.x > 0)
                {
                    // Movimiento hacia la derecha
                    anim.Play("Dog_MoveRight");
                }
                else
                {
                    // Movimiento hacia la izquierda
                    anim.Play("Dog_MoveLeft");
                }
            }
            else
            {
                // Movimiento hacia arriba o hacia abajo
                if (direction.y > 0)
                {
                    // Movimiento hacia arriba
                    anim.Play("Dog_MoveUp");
                }
                else
                {
                    // Movimiento hacia abajo
                    anim.Play("Dog_MoveDown");
                }
            }
            yield return null;
        }
    }

}
