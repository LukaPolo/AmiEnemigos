using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePosition : MonoBehaviour
{
    [SerializeField] private int timer = 60;
    [SerializeField] private float secondTimer = 0.5f;
    [SerializeField] private int phase;
    private Collider2D objectCollider;

    void Start()
    {
        RandomPos();
        phase = 1;
        objectCollider = GetComponent<Collider2D>();
        StartCoroutine(Phase1Timer());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Rat") || collision.CompareTag("Obstacle"))
        {
            switch (phase)
            {
                case 1:
                    RandomPos();
                    break;
                case 2:
                    StartCoroutine(DisableCollisionsTemporarily());
                    transform.position = new Vector2(0f, 4.15f);                    
                    phase = 3;                    
                    break;
                case 3:
                    transform.position = new Vector2(0f, 2.4f);
                    StartCoroutine(DisableCollisionsTemporarily());
                    
                    phase = 4;
                    
                    break;
                case 4:
                    transform.position = new Vector2(-10.75f, 5.5f);
                    break;
            }           
        }
    }

    private void RandomPos()
    {
        transform.position = new Vector2((Random.Range(-9f,9f)),(Random.Range(-5f, 3f)));
    }

    private IEnumerator Phase1Timer()
    {
        float elapsed = 0f;
        while (elapsed < timer)
        {
            yield return new WaitForSeconds(1f);
            elapsed += 1f;
        }
        transform.position = new Vector2(0f, 2.4f);
                
        phase = 2;
    }

    // Se desactiva el collider para evitar colisiones durante un tiempo
    // y luego lo vuelve a activar
    private IEnumerator DisableCollisionsTemporarily()
    {
        
        objectCollider.enabled = false;        
        yield return new WaitForSeconds(secondTimer);
        objectCollider.enabled = true; // Reactiva el collider
    }
}
