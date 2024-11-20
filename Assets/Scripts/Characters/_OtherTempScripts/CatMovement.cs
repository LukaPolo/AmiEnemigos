using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private bool holdingObject; public bool HoldingObject { get => holdingObject; set => holdingObject = value; }

    [SerializeField] private bool pushingObject; public bool PushingObject { get => pushingObject; set => pushingObject = value; }
    private bool canMove; public bool CanMove { set => canMove = value; }
    private Rigidbody2D rb;
    Vector2 input;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Move(input);
            ChooseAnim(input);
        }
        else
        {
            rb.velocity = Vector3.zero;
            anim.Play("Idle");
        }
        
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
                    if (holdingObject)
                    {
                        // Sosteniendo hacia la derecha
                        anim.Play("HoldRight");
                    }
                    else if (pushingObject) 
                    {
                        // Empujando hacia la derecha
                        anim.Play("PushRight");
                    }
                    else
                    {
                        // Movimiento hacia la derecha
                        anim.Play("MoveRight");
                    }
                }
                else
                {
                    if (holdingObject)
                    {
                        // Sosteniendo hacia la izquierda
                        anim.Play("HoldLeft");
                    }
                    else if (pushingObject)
                    {
                        // Empujando hacia la izquierda
                        anim.Play("PushLeft");
                    }
                    else
                    {
                        // Movimiento hacia la izquierda
                        anim.Play("MoveLeft");
                    }
                }
            }
            else
            {
                if (holdingObject) return;
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
            if (!holdingObject)
            {
                anim.Play("Idle");
            }            
        }        
    }
}
