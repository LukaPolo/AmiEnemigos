using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatIdle : CatStateLevel2{
    public void OnEnable(){
        InputManager.moveInput += MovePlayer;
        Cat.PlayAnim("Cat.Idle");
    }

    public void OnDisable(){
        InputManager.moveInput -= MovePlayer;
    }

    void Update(){
        if(Cat.HoldingObject){
            if(Cat.IsFacingRight){
                Cat.PlayAnim("HoldRight");
            }else{
                Cat.PlayAnim("HoldLeft");
            }
        }else{
            Cat.PlayAnim("Idle");
        }
    }

    public void MovePlayer(Vector2 moveInput){
        if(moveInput != Vector2.zero && Cat.CanMove){
            StateMachine.ChangeState("WALK");
        }
    }
}
