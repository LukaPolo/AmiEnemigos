using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCalm : CatState{
    void OnEnable(){
        Cat.calmed?.Invoke();
        Cat.PlayMusic("CatCalm", true);
        Cat.PlayAnim("Cat.Idle");
    }
}