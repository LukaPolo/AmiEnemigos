using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarHUD : MonoBehaviour{
    [SerializeField] private Cat target;
    [SerializeField] private Image fill;

    void Start(){
        Cat.angerChanged += ChangeFillAmount;
        ChangeFillAmount();
    }

    public void ChangeFillAmount(){
        fill.fillAmount = (float)target.Anger / (float)target.Data.MaxAnger;
    }
}