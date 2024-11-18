using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    Vector2 input;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
    }

    private void FixedUpdate()
    {
        Move(input);
        ChooseAnim(input);
    }

    void Move(Vector2 input)
    {
        rb.velocity = input * speed;
    }

    void ChooseAnim(Vector2 input)
    {
        if(input != Vector2.zero)
        {
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                // Movimiento en X
                if (input.x > 0)
                {
                    // Movimiento hacia la derecha
                    anim.Play("MoveRight");
                }
                else
                {
                    // Movimiento hacia la izquierda
                    anim.Play("MoveLeft");
                }
            }
            else
            {
                // Movimiento en Y
                if (input.y > 0)
                {
                    // Movimiento hacia arriba
                    anim.Play("MoveUp");
                }
                else
                {
                    // Movimiento hacia abajo
                    anim.Play("MoveDown");
                }
            }
        }
        else
        {
            anim.Play("Idle");
        }        
    }
}
