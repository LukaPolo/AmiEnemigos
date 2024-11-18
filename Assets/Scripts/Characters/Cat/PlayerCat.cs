using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCat : Character
{
    [SerializeField] private CatData data; public CatData Data { get => data; }


    void Awake()
    {
        Initialize(Data);
    }
}
