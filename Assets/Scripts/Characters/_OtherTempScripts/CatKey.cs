using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatKey : MonoBehaviour
{
    [SerializeField] private GameObject point;

    [SerializeField] private bool hasKey; public bool HasKey { get => hasKey; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("HeldObject"))  // comparamos el tag del objecto
        {
            hasKey = true;
            other.transform.position = point.transform.position;
            other.gameObject.transform.SetParent(point.gameObject.transform);
            hasKey = true;
        }
    }
}
