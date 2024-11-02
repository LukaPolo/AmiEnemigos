using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatWalk : RatState{
    private CharacterMovement mov;

    public override void Awake(){
        base.Awake();
        mov = GetComponent<CharacterMovement>();
    }

    public void OnEnable(){
        InputManager.moveInput += MovePlayer;
    }

    public void OnDisable(){
        InputManager.moveInput -= MovePlayer;
    }

    public void MovePlayer(Vector2 moveInput){
        if(moveInput != Vector2.zero){
            mov.Move(moveInput, StateMachine.Speed);
            mov.RotateToMovementDirection(StateMachine.Speed * 100);
        }else{
            mov.Move(Vector2.zero, 0);
            StateMachine.ChangeState("IDLE");
        }
    }
}