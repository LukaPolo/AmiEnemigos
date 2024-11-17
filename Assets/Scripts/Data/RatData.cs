using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rat Data", menuName = "Character Data/Rat Data")]
public class RatData : CharacterData{
    [SerializeField] private float rotationSpeed; public float RotationSpeed{get => rotationSpeed;}
    [SerializeField] private float strength; public float Strength{get => strength;}
    [SerializeField] private float weight; public float Weight{get => weight;}
    [SerializeField] private int maxLives; public int MaxLives{get => maxLives;}
}