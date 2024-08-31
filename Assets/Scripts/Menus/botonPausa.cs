using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botonPausa : MonoBehaviour
{
     public void volver()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void reiniciar()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void salir()
    {
        SceneManager.LoadScene("MenuInicio");
    }
}
