using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausa : MonoBehaviour 
 {
     public void volver()
    {
        SceneManager.LoadScene("Nivel1");
        pez.comida = false;
        Movimiento.objetos = 0;
        spawnPez.cantidad = 0;
        Gato.velX = 0.8f * Time.deltaTime;
    }

    public void reiniciar()
    {
        SceneManager.LoadScene("Nivel1");
        pez.comida = false;
        Movimiento.objetos = 0;
        spawnPez.cantidad = 0;
        Gato.velX = 0.8f * Time.deltaTime;
    }

    public void salir()
    {
        SceneManager.LoadScene("MenuInicio");
    }
}
