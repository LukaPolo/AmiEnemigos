using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour{
    [SerializeField] private List<GameObject> foods = new List<GameObject>();
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private GameObject lastFood;
    [SerializeField] private Transform lastSpawnPoint;
    [SerializeField] private int foodID;
    [SerializeField] private int pointID;

    void Awake(){
        Cat.angry += SpawnFood;
        Cat.calmed += SpawnLastFood;
        SpawnFood();
    }

    public void SpawnFood(){
        foodID = Random.Range(0, foods.Count); //Se selecciona una comida al azar
        pointID = Random.Range(0, spawnPoints.Count); //Se selecciona un lugar al azar
        Instantiate(foods[foodID], spawnPoints[pointID].position, spawnPoints[pointID].rotation); //Genera la comida en el lugar
    }

    public void SpawnLastFood(){
        Instantiate(lastFood, lastSpawnPoint.position, lastSpawnPoint.rotation); //Genera el queso
    }
}