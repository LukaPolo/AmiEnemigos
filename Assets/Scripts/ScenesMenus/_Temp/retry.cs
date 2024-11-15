using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retry : MonoBehaviour
{
     public void EscenaJuego()
    {
        SceneManager.LoadScene("Historia");
    }

     public void Salir()
    {
        SceneManager.LoadScene("MenuInicio");
    }

}
