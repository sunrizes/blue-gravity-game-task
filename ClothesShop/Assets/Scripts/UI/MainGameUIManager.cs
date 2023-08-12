using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainGameUIManager : MonoBehaviour
{
    public static MainGameUIManager Instance;

    public TextMeshProUGUI cashAmount;

    public GameObject inventoryPanel;

    [Header("Clothes Purchase Panel")]
    public GameObject clothesPurchasePanel;
    public TextMeshProUGUI clothesName;
    public TextMeshProUGUI clothesPrice;
    public TextMeshProUGUI clothesDescription;
    public Image clothesIcon;
    public Button purchaseButton;

    private void Start()
    {
        if (Instance == null) Instance = this;
    }

    public void UpdateCashAmount(int amount)
    {
        cashAmount.text = $"$:{amount}";
    }

    public void ShowInventory(bool show)
    {
        inventoryPanel.gameObject.SetActive(show);
    }

    public void ShowClothesPurchasePanel(bool show)
    {
        clothesPurchasePanel.SetActive(show);
    }
}
