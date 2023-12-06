using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/FridgeItemData", order = 1)]
public class FridgeItemData : ScriptableObject
{
    public Sprite showingSprite;
    public Sprite hiddenSprite;
}
