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
                HealthPotion,
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
                        case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionSprite;
                        case ItemType.Coin:         return ItemAssets.Instance.coinSprite;
                        case ItemType.Tree:         return ItemAssets.Instance.treeSprite;

                }
        }
}
