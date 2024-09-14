using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    private AttackGenerator attackGenerator;
    [SerializeField]
    private GameObject statusGen;
    [SerializeField]
    private float velocity;
    private void Start()
    {
        GameObject parentObject = GameObject.Find("Enemigo");
        attackGenerator = parentObject.GetComponentInChildren<AttackGenerator>();
        //rataInteractions = gameObject.GetComponent<RataInteractions>();
    }
    void Update()
    {
        switch (attackGenerator.Status)
        {
            case "ataque1":
                velocity = 4f;
                break;
            case "ataque2":
                velocity = 5f;
                break;
            case "stop":
                Destroy(gameObject);
                break;
        }
        transform.Translate(Vector3.up * velocity * Time.deltaTime);
    }
}
