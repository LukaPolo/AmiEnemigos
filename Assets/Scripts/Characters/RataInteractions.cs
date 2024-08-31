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
    private void Start()
    {
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
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemigo"))
        {
            life--;
            oof.Play();
        }
    }
    
}
