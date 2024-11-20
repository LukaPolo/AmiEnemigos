using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingObject : MonoBehaviour
{

    [SerializeField] private bool objectFallen; public bool ObjectFallen { get => objectFallen; }
    [SerializeField] private Animator anim;
    [SerializeField] private bool isShaking;
    [SerializeField] private bool catIsHolding;

    [SerializeField] private float shakeDuration = 10f; // Tiempo límite para que caiga si no lo sostiene el gato
    [SerializeField] private float holdDuration = 2f;   // Tiempo necesario para que el gato lo estabilice

    private Coroutine shakeCoroutine;
    private Coroutine holdCoroutine;

    [SerializeField]  private CatMovement catMovement;
    // Start is called before the first frame update
    void Start()
    {
        objectFallen = false;
        anim = GetComponent<Animator>();
        anim.SetInteger("ObjectStatus", 0);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Dog") && !isShaking && !catIsHolding)
        {
            isShaking = true;
            anim.SetInteger("ObjectStatus", 1);
            shakeCoroutine = StartCoroutine(ShakeTimer());
        } else if (other.CompareTag("Player") && isShaking)
        {
            catIsHolding = true;
            catMovement.HoldingObject = true;
            if (shakeCoroutine != null)
            {
                StopCoroutine(shakeCoroutine); // Detenemos la caída mientras el gato sostiene
            }
            holdCoroutine = StartCoroutine(HoldTimer());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && catIsHolding)
        {
            // Gato deja de sostener el objeto
            catIsHolding = false;
            if (holdCoroutine != null)
            {
                StopCoroutine(holdCoroutine);
            }
            // Reiniciamos el temporizador de caída si aún está temblando
            if (isShaking && shakeCoroutine == null)
            {
                shakeCoroutine = StartCoroutine(ShakeTimer());
            }
            catMovement.HoldingObject = false;
        }
    }

    private IEnumerator ShakeTimer()
    {
        float elapsed = 0f;
        while (elapsed < shakeDuration)
        {
            yield return new WaitForSeconds(1f);
            elapsed += 1f;
        }

        // Si el gato no sostiene el objeto a tiempo, este cae
        anim.SetInteger("ObjectStatus", 2); // Estado de caída
        isShaking = false;
        catMovement.CanMove = false;
        Invoke("ObjectHasFallen", 2);
        
    }

    private IEnumerator HoldTimer()
    {
        float elapsed = 0f;
        while (elapsed < holdDuration)
        {
            yield return new WaitForSeconds(1f);
            elapsed += 1f;
        }
        // Si el gato sostiene el objeto por suficiente tiempo, este se estabiliza
        anim.SetInteger("ObjectStatus", 0); // Estado de estabilidad
        isShaking = false;
        catIsHolding = false;
        catMovement.HoldingObject = false;
    }

    void ObjectHasFallen()
    {
        objectFallen = true;
    }
}
