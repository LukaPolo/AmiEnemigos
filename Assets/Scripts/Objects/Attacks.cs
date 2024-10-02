using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    [SerializeField]
    private float velocity;
    public float Velocity { get => velocity; set => velocity = value; }

    void Update()
    {
        transform.Translate(Vector3.up * velocity * Time.deltaTime);
    }
}
