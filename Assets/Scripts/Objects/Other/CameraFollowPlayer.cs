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
        // Obtén la posición deseada de la cámara basada en el jugador
        Vector3 targetPosition = player.position;

        // Limita la posición de la cámara dentro de los límites
        float clampedX = Mathf.Clamp(targetPosition.x, leftLimit, rightLimit);
        float clampedY = Mathf.Clamp(targetPosition.y, bottomLimit, topLimit);

        // Mantén la posición Z actual de la cámara
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
