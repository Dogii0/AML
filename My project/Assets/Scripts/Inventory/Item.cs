using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
        public enum ItemType
        {
                Coin,
                Tree,
                Umbrella,
                FireExt,
                Kimbap,
                Samgak,
                Milk
        }

        public ItemType itemType;
        public int amount;

        public Sprite GetSprite()
        {
                switch (itemType)
                {
                        default:
                        case ItemType.Coin:         return ItemAssets.Instance.coinSprite;
                        case ItemType.Tree:         return ItemAssets.Instance.treeSprite;
                        case ItemType.Umbrella:         return ItemAssets.Instance.umbrellaSprite;
                        case ItemType.FireExt:         return ItemAssets.Instance.fireExtSprite;
                        case ItemType.Kimbap:         return ItemAssets.Instance.kimbapSprite;
                        case ItemType.Samgak:         return ItemAssets.Instance.samgakSprite;
                        case ItemType.Milk:         return ItemAssets.Instance.milkSprite;
                }
        }

        public bool IsStackable()
        {
                switch (itemType)
                {
                        default: 
                        case ItemType.Coin:
                        case ItemType.Kimbap:
                        case ItemType.Samgak:
                        case ItemType.Milk:
                                return true;
                        case ItemType.Tree:
                        case ItemType.Umbrella:
                        case ItemType.FireExt:
                                return false;
                }
        }
}
