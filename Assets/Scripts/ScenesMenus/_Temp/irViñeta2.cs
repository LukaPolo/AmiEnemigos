using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class irViñeta2 : MonoBehaviour
{
    public void EscenaJuego()
    {
        SceneManager.LoadScene("Vineta2");
    }


    public void Salir()
    {
        Application.Quit();
    }

}
