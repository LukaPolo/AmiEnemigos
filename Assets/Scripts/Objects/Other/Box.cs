using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private GameObject screen;
    private Fade fade;

    [SerializeField] private GameObject catPlayer;
    private CatMovement cat;

    private Animator animator;
    [SerializeField] private string animName;
    private bool isPlaying = false;

    [SerializeField] private float probability;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        fade = screen.GetComponent<Fade>();
        cat = catPlayer.GetComponent<CatMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            cat.CanMove = false;
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            // Comprueba si la animación activa ha terminado
            if (stateInfo.IsName(animName) && stateInfo.normalizedTime >= 1f)
            {                
                fade.PlayFade();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!willFall()) return;
            Debug.Log("colision con caja");
            animator.Play("Fall");
            isPlaying = true;
        }
    }

    bool willFall()
    {
        // Genera un número aleatorio entre 0 y 100.
        float randomNum = Random.Range(0f, 100f);

        // El evento ocurre si el número aleatorio es menor o igual a la probabilidad.
        return randomNum <= probability;
    }
}
