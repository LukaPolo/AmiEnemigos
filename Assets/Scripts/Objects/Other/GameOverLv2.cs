using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverLv2 : MonoBehaviour
{
    [SerializeField] private GameObject object1TV;
    [SerializeField] private GameObject object2Table;
    [SerializeField] private GameObject object3FlowerPot;
    [SerializeField] private GameObject screen;
    private ShakingObject tv;
    private ShakingObject table;
    private ShakingObject flowerpot;
    private Fade fade;
    private bool bandera;
    // Start is called before the first frame update
    void Start()
    {
        bandera = true;
        tv = object1TV.GetComponent<ShakingObject>();
        table = object2Table.GetComponent<ShakingObject>();
        flowerpot = object3FlowerPot.GetComponent<ShakingObject>();
        fade = screen.GetComponent<Fade>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bandera)
        {
            if (tv.ObjectFallen || table.ObjectFallen || flowerpot.ObjectFallen)
            {
                bandera = false;
                fade.PlayFade();
            }
        }
        
    }
}
