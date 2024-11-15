using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatIdle : RatState{
    public void OnEnable(){
        InputManager.moveInput += MovePlayer;
        Rat.PlayAnim("Rat.Idle");
    }

    public void OnDisable(){
        InputManager.moveInput -= MovePlayer;
    }

    public void MovePlayer(Vector2 moveInput){
        if(moveInput != Vector2.zero){
            StateMachine.ChangeState("WALK");
        }
    }
}