using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAnims : MonoBehaviour
{
    [SerializeField] private string objetivo;
    private Animator anim;
    private bool isActive;

    private void Start()
    {
        anim = GetComponent<Animator>();        

    }
    // Update is called once per frame
    void Update()
    {
        if (!gameObject.activeSelf) return;
        if (!isActive)
        {
            if (anim != null && !anim.isActiveAndEnabled)
            {
                anim.enabled = true;
            }
            isActive = true;
            StartCoroutine(FollowPlayer());
        }
    }
    IEnumerator FollowPlayer()
    {
        while (!anim.isActiveAndEnabled)
        {
            yield return null;
        }

        while (true)
        {
            GameObject targetObject = GameObject.Find(objetivo); 
            Vector2 direction = (targetObject.transform.position - transform.position).normalized;
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
