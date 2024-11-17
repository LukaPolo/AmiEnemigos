using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHelder : MonoBehaviour{
    public static Action lastFoodHeld;
    [SerializeField] private Rat owner;
    [SerializeField] private GameObject heldObject;
    [SerializeField] private bool canCollect; public bool CanCollect{get => canCollect; set => canCollect = value;}

    void Awake(){
        InputManager.interactInput += ReleaseObject;
        canCollect = true;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(heldObject == null && canCollect){
            switch(other.tag){
                case "Food":
                    break;
                case "LastFood":
                    InputManager.interactInput -= ReleaseObject;
                    other.GetComponent<Rigidbody2D>().simulated = false;
                    lastFoodHeld?.Invoke();
                    break;
                default:
                    return;
            }
            CollectObject(other.gameObject);
        }
    }

    public void CollectObject(GameObject newObject){
        canCollect = false;
        newObject.transform.parent = transform;
        newObject.transform.position = transform.position;
        heldObject = newObject;
        owner.CarriedWeight = heldObject.GetComponent<Food>().Data.Weight;
    }

    public void ReleaseObject(){
        if(heldObject != null){
            heldObject.transform.parent = null;
            heldObject = null;
            owner.CarriedWeight = 0f;
            StartCoroutine(CollectCooldown(0.25f));
        }
    }

    public IEnumerator CollectCooldown(float time){
        yield return new WaitForSeconds(time);
        canCollect = true;
    }
}