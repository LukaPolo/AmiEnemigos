using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cat Data", menuName = "Character Data/Cat Data")]
public class CatData : CharacterData{
    [SerializeField] private float patrolSpeed; public float PatrolSpeed{get => patrolSpeed;}
    [SerializeField] private float dashSpeed; public float DashSpeed{get => dashSpeed;}
    [SerializeField] private float chaseSpeed; public float ChaseSpeed{get => chaseSpeed;}
    [SerializeField] private float attackDelay; public float AttackDelay{get => attackDelay;}
    [SerializeField] private float attackCadence; public float AttackCadence{get => attackCadence;}
    [SerializeField] private int maxAnger; public int MaxAnger{get => maxAnger;}
    [SerializeField] private List<GameObject> projectiles = new List<GameObject>(); public List<GameObject> Projectiles{get => projectiles;}

    public GameObject GetProjectile(int id){
        return projectiles[id];
    }
}