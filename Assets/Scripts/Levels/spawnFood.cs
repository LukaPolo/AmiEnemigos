using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFood : MonoBehaviour
{
    private AudioSource foodSpawnSound;
    public static bool generateFood = true;
    [SerializeField]
    private GameObject[] food;//Aqui pondremos en el inspector todas las comidas que se requieran
    [SerializeField]
    private Transform[] puntoSpawn;//Aqui pondremos en el inspector todas los GameObjets vacios donde aparecerá la comida
    [SerializeField]
    private int foodArrayPos;//Indice para la lista de comidas
    [SerializeField]
    private int spawnArrayPos;//Indice para la lista de posiciones de spawn

    void Start()
    {
        foodSpawnSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (generateFood){
            Generate();
        }        
    }
    void Generate()
    {
        foodArrayPos = Random.Range(0, food.Length);//Se aleatoriza el indice entre 0 y el ultimo elemento de la lista
        spawnArrayPos = Random.Range(0, puntoSpawn.Length);//Lo mismo de arriba
        foodSpawnSound.Play();
        //Genera la comida aleatoria en posicion aleatoria
        Instantiate(food[foodArrayPos], puntoSpawn[spawnArrayPos].transform.position, puntoSpawn[spawnArrayPos].transform.rotation);
        generateFood = false; //Hace falta que otro script vuelva a esto verdadero cuando se deje la comida en el plato
        //A ese script le hace falta agregar una condicion para que no solo con acercarse cree comida
        //el Generate podría ser llamado desde el plato cuando se entregue comida en vez desde el Update
    }
}
