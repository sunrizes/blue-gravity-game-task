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

    public bool equippable { get; set; } = false;

    private void OnEnable()
    {
        clothingIcon.sprite = clothingItem.icon;
        clothingName.text = clothingItem.name;
    }

    public void Equip()
    {
        if (equippable)
        {
            switch (clothingItem.clothingType)
            {
                case ClothingType.Head:
                    PlayerController.Instance.clothesHead = clothingItem;
                    break;

                case ClothingType.Torso:
                    PlayerController.Instance.clothesTorso = clothingItem;
                    break;

                case ClothingType.Legs:
                    PlayerController.Instance.clothesLegs = clothingItem;
                    break;

                case ClothingType.Feet:
                    PlayerController.Instance.clothesFeet = clothingItem;
                    break;
            }

            MainGameUIManager.Instance.RefreshPlayerIcons();
        }
    }
}