using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public ClothingItem clothingItem { get; set; }
    public Image clothingIcon;
    public TextMeshProUGUI clothingName;

    private void Awake()
    {
        clothingIcon.sprite = clothingItem.icon;
        clothingName.text = clothingItem.name;
    }
}