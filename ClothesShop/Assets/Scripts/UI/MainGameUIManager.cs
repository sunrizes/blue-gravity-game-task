using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(-4)]
public class MainGameUIManager : MonoBehaviour
{
    public static MainGameUIManager Instance;

    public TextMeshProUGUI cashAmount;

    public ClothesPurchase currentClothesPurchase { get; set; } = null;

    [Header("Inventory Panel")]
    public GameObject inventoryPanel;
    public Image playerHeadIcon;
    public Image playerTorsoIcon;
    public Image playerLegsIcon;
    public Image playerFeetIcon;

    [Space(10)]

    [Header("Clothes Purchase Panel")]
    public GameObject clothesPurchasePanel;
    public TextMeshProUGUI clothesName;
    public TextMeshProUGUI clothesPrice;
    public TextMeshProUGUI clothesDescription;
    public Image clothesIcon;
    public Button purchaseButton;

    [Space(10)]

    public GameObject purchasePromptPanel;
    public TextMeshProUGUI purchasePromptMessage;
    public GameObject purchaseFailPanel;
    public GameObject purchaseBasketFull;
    public GameObject purchaseNoItems;

    [Space(10)]
    public GameObject pauseMenu;

    private void Start()
    {
        if (Instance == null) Instance = this;

        RefreshPlayerIcons();
    }

    public void UpdateCashAmount(int amount)
    {
        cashAmount.text = $"$:{amount}";
    }

    public void PurchaseItem()
    {
        currentClothesPurchase.Purchase();
    }

    public void ShowInventory(bool value)
    {
        inventoryPanel.SetActive(value);
    }

    public void RefreshPlayerIcons()
    {
        if (PlayerController.Instance.clothesHead is not null)
            playerHeadIcon.sprite = PlayerController.Instance.clothesHead.icon;

        if (PlayerController.Instance.clothesTorso is not null)
            playerTorsoIcon.sprite = PlayerController.Instance.clothesTorso.icon;

        if (PlayerController.Instance.clothesLegs is not null)
            playerLegsIcon.sprite = PlayerController.Instance.clothesLegs.icon;

        if (PlayerController.Instance.clothesHead is not null)
            playerFeetIcon.sprite = PlayerController.Instance.clothesFeet.icon;
    }

    public void ShowPauseMenu()
    {
        if (Time.timeScale != 0.0f)
        {
            Time.timeScale = 0.0f;
        }
        else if (Time.timeScale == 0.0f)
        {
            Time.timeScale = 1.0f;
        }

        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }

    public void PauseMainMenu()
    {
        SceneManager.LoadScene("01_MainMenu");
    }

    public void PauseQuit()
    {
        Application.Quit();
    }
}