using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : Character{
    [SerializeField] private CatData data; public CatData Data{get => data;}
    [SerializeField] private float speed;
    [SerializeField] private bool holdingObject; public bool HoldingObject { get => holdingObject; set => holdingObject = value; }

    [SerializeField] private bool pushingObject; public bool PushingObject { get => pushingObject; set => pushingObject = value; }
    private bool canMove; public bool CanMove{get => canMove; set => canMove = value;}
    private bool isFacingRight; public bool IsFacingRight{get => isFacingRight; set => isFacingRight = value;}
    private Rigidbody2D rb;
    Vector2 input;
    // Start is called before the first frame update
    void Awake(){
        Initialize(Data);
        canMove = true;
        GameManager.Sound.PlayMusic("Level2", true);
    }
}