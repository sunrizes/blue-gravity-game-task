using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public InventoryItem inventoryItem;

    public GameObject inventoryRoot;

    public List<ClothingItem> clothes;

    public const int INVENTORY_MAX_CAPACITY = 16;

    private void Start()
    {
        if (Instance == null) Instance = this;
    }

    public void AddClothes(ClothingItem item)
    {
        clothes.Add(item);
    }

    public void RemoveClothes(ClothingItem item)
    {
        clothes.Remove(item);
    }

    public void ListItems()
    {
        // Cleanup

        for (int i = 0; i < inventoryRoot.transform.childCount; i++)
        {
            Destroy(inventoryRoot.transform.GetChild(i));
        }

        //Listing

        foreach (ClothingItem clothingItem in clothes)
        {
            InventoryItem item = Instantiate(inventoryItem, inventoryRoot.transform);
            item.clothingItem = clothingItem;
        }
    }
}