using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatWalk : State{
    private CharacterMovement mov;
    [SerializeField] private float speed = 5f;

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
            mov.Move(moveInput, speed);
            mov.RotateToMovementDirection(speed * 100);
        }else{
            mov.Move(Vector2.zero, 0);
            StateMachine.ChangeState("IDLE");
        }
    }
}