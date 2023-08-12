using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ClothingSprite
{
    public int ID;
    public Sprite clothingSprite;
    public Orientation orientation;
}

[System.Serializable]
public class ClothingPoint
{
    public int ID;
    public SpriteRenderer clothingPoint;
}