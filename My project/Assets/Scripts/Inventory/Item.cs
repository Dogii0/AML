using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
        public enum ItemType
        {
                Weapon,
                Food,
                Coin,
                Tree
        }

        public ItemType itemType;
        public int amount;

        public Sprite GetSprite()
        {
                switch (itemType)
                {
                        default:
                        case ItemType.Weapon:       return ItemAssets.Instance.weaponSprite;
                        case ItemType.Food:         return ItemAssets.Instance.foodSprite;
                        case ItemType.Coin:         return ItemAssets.Instance.coinSprite;
                        case ItemType.Tree:         return ItemAssets.Instance.treeSprite;

                }
        }

        public bool IsStackable()
        {
                switch (itemType)
                {
                        default: 
                        case ItemType.Coin:
                        case ItemType.Food:
                                return true;
                        case ItemType.Tree:
                        case ItemType.Weapon:
                                return false;
                }
        }
}
