using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour{
    public static Action<Vector2> moveInput;
    public static Action interactInput, pauseInput;
    private Vector2 axisValues;

    void Update(){
        axisValues.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        axisValues.Normalize();
        moveInput?.Invoke(axisValues);
        if(Input.GetButtonDown("Interact")) interactInput?.Invoke();
        if(Input.GetButtonDown("Pause")) pauseInput?.Invoke();
    }
}