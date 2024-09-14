using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatChargedAttack : MonoBehaviour
{
    [SerializeField]
    private Transform target;//asignamos el raton desde el arbol de jerarquía
    private float timeSearch;
    [SerializeField]
    private float speed;
    Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        timeSearch = 3f; //tiempo que se queda buscando al raton
        StartCoroutine("chargedAttack");
    }

    IEnumerator chargedAttack()
    {
        while (true)
        {
            // Bucle que se ejecutará mientras el tiempo restante sea mayor que 0
            while (timeSearch > 0)
            {
                Vector3 look = transform.InverseTransformPoint(target.transform.position);
                float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg + 90;
                transform.Rotate(0, 0, angle);
                timeSearch -= Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSecondsRealtime(0.1f);
            lastPos = target.transform.position;//guardamos la ultima posicion del raton conocida
            while (transform.position != lastPos)
            {
                transform.position = Vector3.MoveTowards(transform.position, lastPos, speed * Time.deltaTime);
                yield return null;
            }
            timeSearch = 3f;
        }
    }
}
