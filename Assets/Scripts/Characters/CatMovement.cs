using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//DEJO ESTO POR SI SE LLEGA A USAR DE ALGUNA MANERA
public class CatMovement : MonoBehaviour
{
    
    private float velX = 6f;//Ver despues si eso se puede heredar, depende el caso
    [SerializeField]
    private Transform[] checkpoint; //Arraylist que contiene las posiciones de los puntos del objeto). Requiere tener 2 GameObjects vacios que funcionen como punto objetivo
    public static bool startMoving;
    public static bool isMoving;
    
    void Start()
    {
        startMoving = false;
        isMoving = true;
    }
    private void Update()
    {
        //Esta parte del Update se podria mejorar de alguna manera para que solo se llame a la corrutina sin tener que pasar por aqui
        //Una solucion temporal fue poner simplemente un bool (startMoving) para que se ejecute 1 vez al ser True
        if (startMoving)
        {
            StartCoroutine("move");
            startMoving = false;
        }
        
    }

    //Corrutina
    IEnumerator move()
    {
        int i = 1;
        Vector3 newPosition = new Vector3(checkpoint[i].position.x, transform.position.y, transform.position.z);
        while (isMoving)//Mientras esto sea verdadero, el movimiento de un punto a otro se repite indefinidamente
        {
            while (transform.position != newPosition)//La posicion actual debe de ser diferente a la nueva. En este caso la actual y el primer punto objetivo[0]
            {
                transform.position = Vector3.MoveTowards(transform.position, newPosition, velX*Time.deltaTime);//Se procede a trasladarse al punto objetivo [0]
                yield return null;
            }
            yield return new WaitForSecondsRealtime(0.1f);
            if (i < 1)//Se hace este if solo para recorrer el array
            {
                i++;
            }
            else
            {
                i = 0;//Volvemos inmediatamente al principio de array porque sabemos que solo hay 2 puntos que debe recorrer
            }
            newPosition = new Vector3(checkpoint[i].position.x, transform.position.y, transform.position.z);//La nueva posicion objetivo será el [1] o en caso de volver [0]
        }
    }
}
