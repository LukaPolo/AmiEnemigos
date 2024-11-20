using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDogRat : MonoBehaviour
{
    [SerializeField] private GameObject dogIdle;
    [SerializeField] private GameObject ratIdle;
    [SerializeField] private GameObject dogMove;
    [SerializeField] private GameObject ratMove;
    [SerializeField] private Transform dogDestination;
    [SerializeField] private Transform ratDestination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CatKey cat = other.GetComponent<CatKey>();
            if (cat.HasKey)
            {
                dogIdle.transform.position = dogDestination.position;
                ratIdle.transform.position = ratDestination.position;
                ratIdle.transform.eulerAngles = new Vector2(180,0);
                dogIdle.SetActive(false);
                ratIdle.SetActive(false);
                dogMove.SetActive(true);
                ratMove.SetActive(true);
                Destroy(this);
            }
        }
    }
}
