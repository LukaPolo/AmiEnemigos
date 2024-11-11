using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RataInteractions : MonoBehaviour
{


    public GameObject[] hearts;
    private int life;
    private AudioSource oof;
    private bool hasCollided = false; // Para saber si ya colisionó
    [SerializeField]
    private bool hasFood;
    public bool HasFood { get => hasFood; set => hasFood = value; }
    private void Start()
    {
        hasFood = false;
        life = hearts.Length;
        oof = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (life < 1)
        {
            Destroy(hearts[0].gameObject);
            SceneManager.LoadScene("GameOver");

        } else if (life < 2)
        {
            Destroy(hearts[1].gameObject);
        }else if (life < 3)
        {
            Destroy(hearts[2].gameObject);
        }
    }
    public void QuitarVida()
    {
        life--;
        oof.Play();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("balas"))
        {
            Destroy(collision.gameObject);
            if (hasCollided) return;// Deshabilita la colision
            QuitarVida();
            hasCollided = true;
            StartCoroutine(InmuneTime());
        }
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            if (hasCollided) return;// Deshabilita la colision
            QuitarVida();
            hasCollided = true;
            StartCoroutine("InmuneTime");
        }
        if (collision.gameObject.CompareTag("food")) {
            hasFood = true;
        }
    }

    private IEnumerator InmuneTime()
    {
        yield return new WaitForSeconds(2f); // Espera un tiempo antes de permitir otra colisión//Equipo de balance cambiar esto
        hasCollided = false; // Habilita nuevamente la colisión
    }

}
