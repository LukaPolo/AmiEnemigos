using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngryBar
{
    public float MaxVida { get; private set; }
    public float ActualVida { get; private set; }
    private Image sistemaVida;

    public AngryBar(float maxVida, Image sistemaVida)
    {
        MaxVida = maxVida;
        ActualVida = MaxVida;
        this.sistemaVida = sistemaVida;
    }

    public void TomarDaño(float cantidad)
    {
        ActualVida -= cantidad;
        ActualizarVida();
    }

    private void ActualizarVida()
    {
        sistemaVida.fillAmount = ActualVida / MaxVida;
    }
}
