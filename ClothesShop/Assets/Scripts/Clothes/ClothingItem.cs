using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClothingItem", menuName = "Clothes/Clothing Item")]
public class ClothingItem : ScriptableObject
{
    public new string name;
    public ClothingType clothingType;
    public int price;
    public string description;
    public List<ClothingSprite> sprites;
}