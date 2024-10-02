using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class irViñeta : MonoBehaviour
{
    public void EscenaJuego()
    {
        SceneManager.LoadScene("Vineta1");
    }


    public void Salir()
    {
        Application.Quit();
    }

}
