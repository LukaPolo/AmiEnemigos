using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class irJuego : MonoBehaviour
{
     public void EscenaJuego()
    {
        SceneManager.LoadScene("Nivel1");
        pez.comida = false;
        Movimiento.objetos = 0;
        spawnPez.cantidad = 0;
        Gato.velX = 0.8f * Time.deltaTime;

    }

}
