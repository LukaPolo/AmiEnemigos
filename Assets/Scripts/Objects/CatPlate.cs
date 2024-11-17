using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPlate : MonoBehaviour{
    [SerializeField] private Cat owner;

    void Awake(){
        Cat.calmed += TurnOffCollision;
    }

    void OnDisable(){
        Cat.calmed -= TurnOffCollision;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Food"){
            other.GetComponent<BoxCollider2D>().enabled = false;
            other.transform.parent.gameObject.GetComponent<ObjectHelder>().ReleaseObject();
            other.transform.parent = transform;
            other.transform.position = transform.position;
            owner.ChangeAnger(other.GetComponent<Food>().Data.AngerModifier);
        }
    }

    public void StoreFood(GameObject food){
        owner.ChangeAnger(food.GetComponent<Food>().Data.AngerModifier);
    }

    public void TurnOffCollision(){
        GetComponent<CircleCollider2D>().enabled = false;
    }
}