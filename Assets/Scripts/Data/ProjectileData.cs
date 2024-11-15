using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile Data", menuName = "Projectile Data")]
public class ProjectileData : ScriptableObject{
    [SerializeField] private float speed; public float Speed{get => speed;}
    [SerializeField] private int lifeModifier; public int LifeModifier{get => lifeModifier;}
}