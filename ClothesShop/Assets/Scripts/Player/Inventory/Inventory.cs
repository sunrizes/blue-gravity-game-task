using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public int money;

    public InventoryItem inventoryItem;

    public GameObject inventoryRoot;

    public GameObject basketRoot;

    public List<ClothingItem> clothes;

    public List<ClothingItem> basket;

    public const int INVENTORY_MAX_CAPACITY = 16;
    public const int BASKET_MAX_CAPACITY = 4;

    private void Start()
    {
        if (Instance == null) Instance = this;

        MainGameUIManager.Instance.UpdateCashAmount(money);

        if (PlayerController.Instance.clothesHead is not null)
            AddClothesInventory(PlayerController.Instance.clothesHead);

        if (PlayerController.Instance.clothesTorso is not null)
            AddClothesInventory(PlayerController.Instance.clothesTorso);

        if (PlayerController.Instance.clothesLegs is not null)
            AddClothesInventory(PlayerController.Instance.clothesLegs);

        if (PlayerController.Instance.clothesFeet is not null)
            AddClothesInventory(PlayerController.Instance.clothesFeet);
    }

    public void AddClothesInventory(ClothingItem item)
    {
        if (clothes.Count < INVENTORY_MAX_CAPACITY)
        {
            clothes.Add(item);
        }
        ListItemsInventory();
    }

    public void RemoveClothesInventory(ClothingItem item)
    {
        clothes.Remove(item);
        ListItemsInventory();
    }

    public void ListItemsInventory()
    {
        // Cleanup

        if (inventoryRoot.transform.childCount > 0)
        {
            for (int i = 0; i < inventoryRoot.transform.childCount; i++)
            {
                Destroy(inventoryRoot.transform.GetChild(i).gameObject);
            }
        }

        //Listing

        foreach (ClothingItem clothingItem in clothes)
        {
            InventoryItem item = Instantiate(inventoryItem, inventoryRoot.transform);
            item.clothingItem = clothingItem;
        }
    }

    public void AddClothesBasket(ClothingItem item)
    {
        if (basket.Count < BASKET_MAX_CAPACITY)
        {
            basket.Add(item);
        }
        ListItemsBasket();
    }

    public void RemoveClothesBasket(ClothingItem item)
    {
        basket.Remove(item);
        ListItemsBasket();
    }

    public void ListItemsBasket()
    {
        // Cleanup

        if (basketRoot.transform.childCount > 0)
        {
            for (int i = 0; i < basketRoot.transform.childCount; i++)
            {
                Destroy(basketRoot.transform.GetChild(i).gameObject);
            }
        }

        //Listing

        foreach (ClothingItem clothingItem in basket)
        {
            InventoryItem item = Instantiate(inventoryItem, basketRoot.transform);
            item.clothingItem = clothingItem;
        }
    }

    public int CalculatePurchase()
    {
        int sum = 0;

        foreach (ClothingItem clothingItem in basket)
        {
            sum += clothingItem.price;
        }

        return sum;
    }

    public void CheckOut()
    {
        money -= CalculatePurchase();

        MainGameUIManager.Instance.UpdateCashAmount(money);

        for (int i = 0; i < basket.Count; i++)
        {
            AddClothesInventory(basket[i]);
        }

        basket.Clear();
        ListItemsInventory();
        ListItemsBasket();

        if (inventoryRoot.transform.childCount > 0)
        {
            for (int i = 0; i < inventoryRoot.transform.childCount; i++)
            {
                inventoryRoot.transform.GetChild(i).GetComponent<InventoryItem>().equippable = true;
            }
        }
    }
}