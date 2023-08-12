using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesPurchase : MonoBehaviour
{
    public ClothingItem clothingItem;
    public bool purchased = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !purchased)
        {
            MainGameUIManager.Instance.currentClothesPurchase = this;
            MainGameUIManager.Instance.clothesPurchasePanel.SetActive(true);
            MainGameUIManager.Instance.clothesName.text = clothingItem.name;
            MainGameUIManager.Instance.clothesDescription.text = clothingItem.description;
            MainGameUIManager.Instance.clothesPrice.text = $"$:{clothingItem.price}";
            MainGameUIManager.Instance.clothesIcon.sprite = clothingItem.icon;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MainGameUIManager.Instance.clothesPurchasePanel.SetActive(false);
        }
    }

    public void Purchase()
    {
        if (Inventory.Instance.basket.Count >= Inventory.BASKET_MAX_CAPACITY)
        {
            MainGameUIManager.Instance.purchaseBasketFull.SetActive(true);
        }
        else
        {
            MainGameUIManager.Instance.clothesPurchasePanel.SetActive(false);
            Inventory.Instance.AddClothesBasket(clothingItem);
            purchased = true;
        }
    }
}