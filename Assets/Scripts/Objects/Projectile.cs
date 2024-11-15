using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour{
    [SerializeField] private ProjectileData data;

    void Update(){
        transform.Translate(Vector3.up * data.Speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other){
        switch(other.tag){
            case "Rat":
                other.GetComponent<Rat>().LoseLife(data.LifeModifier);
                Destroy(gameObject);
                break;
            case "Wall":
                Destroy(gameObject);
                break;
        }
    }
}