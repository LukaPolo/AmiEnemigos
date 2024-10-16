using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatIdle : State{
    public void OnEnable(){
        InputManager.moveInput += MovePlayer;
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