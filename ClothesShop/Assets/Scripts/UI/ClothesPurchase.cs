using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesPurchase : MonoBehaviour
{
    public ClothingItem clothingItem;
    public bool purchased = false;

    MainGameUIManager gameUIManager = MainGameUIManager.Instance;

    private void OnTriggerEnter(Collider other)
    {
        gameUIManager.clothesPurchasePanel.SetActive(true);
        gameUIManager.clothesName.text = clothingItem.name;
        gameUIManager.clothesDescription.text = clothingItem.description;
        gameUIManager.clothesPrice.text = $"$:{clothingItem.price}";
        gameUIManager.clothesIcon.sprite = clothingItem.icon;
    }

    private void OnTriggerExit(Collider other)
    {
        gameUIManager.clothesPurchasePanel.SetActive(false);
    }
}