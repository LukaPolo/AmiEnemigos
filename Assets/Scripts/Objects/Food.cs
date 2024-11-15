using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour{
    [SerializeField] private FoodData data; public FoodData Data{get => data;}
    [SerializeField] private bool isCollected; public bool IsCollected{get => isCollected;}

    void Awake(){
        isCollected = false;
    }
}