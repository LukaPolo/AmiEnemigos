using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Stairs stairs;
    [SerializeField] private GameObject stairVisible;
    [SerializeField] private GameObject invisibleWall;
    [SerializeField] private bool isPressed = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rat"))
        {
            if (!isPressed)
            {
                invisibleWall.SetActive(false);
                stairVisible.SetActive(true);
                stairs.Anim.Play("StairsOpening");
                isPressed = true;
            }
            
        }
    }
}
