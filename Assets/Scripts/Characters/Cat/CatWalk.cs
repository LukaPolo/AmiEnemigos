using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatWalk : CatState
{
    /*private CharacterMovement mov;

    void Awake()
    {
        Initialize();
        mov = GetComponent<CharacterMovement>();
    }

    public void OnEnable()
    {
        InputManager.moveInput += MovePlayer;
    }

    public void OnDisable()
    {
        InputManager.moveInput -= MovePlayer;
        mov.Move(Vector2.zero, 0);
    }

    public void MovePlayer(Vector2 moveInput)
    {
        if (moveInput != Vector2.zero)
        {
            mov.Move(moveInput, Cat.Data.Speed);
            if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
            {
                // Movimiento hacia los lados
                if (moveInput.x > 0)
                {
                    // Movimiento hacia la derecha
                    Cat.PlayAnim("Cat.MoveRight");
                }
                else
                {
                    // Movimiento hacia la izquierda
                    Cat.PlayAnim("Cat.MoveLeft");
                }
            }
            else
            {
                // Movimiento hacia arriba o hacia abajo
                if (moveInput.y > 0)
                {
                    // Movimiento hacia arriba
                    Cat.PlayAnim("Cat.MoveUp");
                }
                else
                {
                    // Movimiento hacia abajo
                    Cat.PlayAnim("Cat.MoveDown");
                }
            }
        }
        else
        {
            StateMachine.ChangeState("IDLE");
        }
    }*/
}
