using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatDeath : RatState{
    void OnEnable(){
        GetComponent<Collider2D>().enabled = false;
        Rat.ratDied?.Invoke();
        Rat.PlayAnim("Rat.Death");
    }
}