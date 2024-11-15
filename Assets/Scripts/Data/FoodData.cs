using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food Data", menuName = "Food Data")]
public class FoodData : ScriptableObject{
    [SerializeField] private float weight; public float Weight{get => weight;}
    [SerializeField] private int angerModifier; public int AngerModifier{get => angerModifier;}
}