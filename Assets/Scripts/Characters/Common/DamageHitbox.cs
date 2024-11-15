using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHitbox : MonoBehaviour{
    [SerializeField] Collider2D area;
    [SerializeField] int damage;

    void Awake(){
        area = GetComponent<Collider2D>();
        area.enabled = false;
    }

    public void Activate(int newDamage){
        area.enabled = true;
        damage = newDamage;
    }

    public void Deactivate(){
        area.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other){
        switch(other.tag){
            case "Rat":
                other.GetComponent<Rat>().LoseLife(damage);
                break;
        }
    }
}