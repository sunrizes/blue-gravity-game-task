using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clerk : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Inventory.Instance.basket.Count <= 0)
            {
                MainGameUIManager.Instance.purchaseNoItems.SetActive(true);
            }
            else
            {
                if (Inventory.Instance.CalculatePurchase() > Inventory.Instance.money)
                {
                    MainGameUIManager.Instance.purchaseFailPanel.SetActive(true);
                }
                else if (Inventory.Instance.CalculatePurchase() <= Inventory.Instance.money)
                {
                    MainGameUIManager.Instance.purchasePromptPanel.SetActive(true);
                    MainGameUIManager.Instance.purchasePromptMessage.text = $"Your total is {Inventory.Instance.CalculatePurchase()}. Do you want to complete the purchase?";
                }
            }
        }
    }
}