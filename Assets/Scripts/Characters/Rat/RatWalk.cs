using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatWalk : RatState{
    private CharacterMovement mov;

    void Awake(){
        Initialize();
        mov = GetComponent<CharacterMovement>();
    }

    public void OnEnable(){
        InputManager.moveInput += MovePlayer;
        Rat.PlayAnim("Rat.Idle");
    }

    public void OnDisable(){
        InputManager.moveInput -= MovePlayer;
        mov.Move(Vector2.zero, 0);
    }

    public void MovePlayer(Vector2 moveInput){
        if(moveInput != Vector2.zero){
            mov.Move(moveInput, Rat.Data.Speed*(Rat.Data.Strength/(Rat.Data.Weight + Rat.CarriedWeight)));
            mov.RotateToMovementDirection(Rat.Data.RotationSpeed);
        }else{
            StateMachine.ChangeState("IDLE");
        }
    }
}