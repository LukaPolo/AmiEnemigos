using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class irViñeta3 : MonoBehaviour
{
    public void EscenaJuego()
    {
        SceneManager.LoadScene("Vineta3");
    }


    public void Salir()
    {
        Application.Quit();
    }

}
