using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour{
    private Rigidbody2D physics;

    void OnEnable(){
        physics = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 moveInput, float speed){
        physics.velocity = moveInput * speed;
    }

    public void RotateToMovementDirection(float rotationSpeed){
        Quaternion lookDirection = Quaternion.LookRotation(Vector3.forward, physics.velocity);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookDirection, rotationSpeed * Time.deltaTime);
    }
}