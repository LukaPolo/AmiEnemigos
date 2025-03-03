using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveIdle : MonoBehaviour
{

    [SerializeField] private GameObject movingCharacter;
    [SerializeField] private GameObject idleCharacter;
    [SerializeField] private string tagCharacter; 
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagCharacter))
        {
            movingCharacter.SetActive(false);
            idleCharacter.SetActive(true);
            Destroy(this);
        }
    }
}
