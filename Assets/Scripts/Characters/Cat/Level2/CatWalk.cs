using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatWalk : CatStateLevel2{
    private CharacterMovement mov;

    void Awake(){
        Initialize();
        mov = GetComponent<CharacterMovement>();
    }

    public void OnEnable(){
        InputManager.moveInput += MovePlayer;
        Cat.PlaySound("Walk", true);
    }

    public void OnDisable(){
        InputManager.moveInput -= MovePlayer;
        mov.Move(Vector2.zero, 0);
        Cat.StopSound();
    }

    void Update(){
        if(Cat.PushingObject){
            if(Cat.IsFacingRight){
                Cat.PlayAnim("PushRight");
            }else{
                Cat.PlayAnim("PushLeft");
            }
        }
    }

    public void MovePlayer(Vector2 moveInput){
        if(moveInput != Vector2.zero && Cat.CanMove){
            mov.Move(moveInput, Cat.Data.Speed);
            if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y)){
                // Movimiento hacia los lados
                if (moveInput.x > 0){
                    // Movimiento hacia la derecha
                    Cat.IsFacingRight = true;
                    Cat.PlayAnim("Cat.MoveRight");
                }else{
                    // Movimiento hacia la izquierda
                    Cat.IsFacingRight = false;
                    Cat.PlayAnim("Cat.MoveLeft");
                }
            }else{
                // Movimiento hacia arriba o hacia abajo
                if (moveInput.y > 0){
                    // Movimiento hacia arriba
                    Cat.PlayAnim("Cat.MoveUp");
                }else{
                    // Movimiento hacia abajo
                    Cat.PlayAnim("Cat.MoveDown");
                }
            }
        }else{
            StateMachine.ChangeState("IDLE");
        }
    }
}