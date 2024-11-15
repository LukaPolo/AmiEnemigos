using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergySlotHUD : MonoBehaviour{
    [SerializeField] private Rat target;
    [SerializeField] private RectTransform slot;
    [SerializeField] private GameObject slotIcon;
    [SerializeField] private float slotWidth;
    private List<GameObject> icons = new List<GameObject>();

    void Start(){
        Rat.livesChanged += ChangeIconAmount;
        SetIcons();
    }

    public void SetIcons(){
        for(int i = 0; i < target.Lives; i++){
            GameObject icon = Instantiate(slotIcon);
            icon.transform.SetParent(slot);
            icon.GetComponent<RectTransform>().anchoredPosition = new Vector2(slot.anchoredPosition.x*2*i, slot.anchoredPosition.y);
            icon.transform.localScale = slot.localScale;
            icons.Add(icon);
        }
    }

    public void ChangeIconAmount(){
        if(target.Lives < icons.Count){
            icons[target.Lives].SetActive(false);
        }
    }
}