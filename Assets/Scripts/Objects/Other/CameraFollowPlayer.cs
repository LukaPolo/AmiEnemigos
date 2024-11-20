using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float leftLimit = -7.45f;
    [SerializeField] private float rightLimit = 7.9f;
    [SerializeField] private float topLimit = 5f;
    [SerializeField] private float bottomLimit = 0.7f;

    void LateUpdate()
    {
        // Obt�n la posici�n deseada de la c�mara basada en el jugador
        Vector3 targetPosition = player.position;

        // Limita la posici�n de la c�mara dentro de los l�mites
        float clampedX = Mathf.Clamp(targetPosition.x, leftLimit, rightLimit);
        float clampedY = Mathf.Clamp(targetPosition.y, bottomLimit, topLimit);

        // Mant�n la posici�n Z actual de la c�mara
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
