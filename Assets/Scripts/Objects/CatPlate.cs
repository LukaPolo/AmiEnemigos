using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPlate : MonoBehaviour{
    [SerializeField] private CatStateMachine owner;

    public void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Rat"){
            owner.ChangeAnger(-10);
        }
    }
}