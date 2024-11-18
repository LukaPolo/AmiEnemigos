using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatIdle : CatState
{
    public void OnEnable()
    {
        InputManager.moveInput += MovePlayer;
        Cat.PlayAnim("Cat.Idle");
    }

    public void OnDisable()
    {
        InputManager.moveInput -= MovePlayer;
    }

    public void MovePlayer(Vector2 moveInput)
    {
        if (moveInput != Vector2.zero)
        {
            StateMachine.ChangeState("WALK");
        }
    }
}
