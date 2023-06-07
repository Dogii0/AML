using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    public Inventory inventory;
    private Transform itemSlot;
    private Transform itemSlotTemplate;
    private GameObject player;
    public PlayerHealth playerHealth;
    private void Awake()
    {
        itemSlot = transform.Find("ItemSlot");
        itemSlotTemplate = itemSlot.Find("ItemSlotTemplate");
        RefreshInventoryItems();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }
    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }
    public void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlot)
        {
            if(child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 65;
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlot).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>   //Use item
            {
                if (item.IsFood())
                {
                    playerHealth.Heal(1);
                    inventory.RemoveItem(item);
                }
                else { Debug.Log("not food bruh"); }
            };
            itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () =>     //Drop item
            {
                if (item.IsStackable())
                {
                    Item duplicateItem = new Item { itemType = item.itemType, amount = item.amount };
                    inventory.RemoveItem(item);
                    ItemWorld.DropItem(duplicateItem);
                }
                else
                {
                    inventory.RemoveItem(item);
                    ItemWorld.DropItem(item);
                }
            };
            
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            TextMeshProUGUI uiText = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1)
            {
                uiText.SetText(item.amount.ToString());
            }
            else
            {
                uiText.SetText("");
            }
            DontDestroyOnLoad(this.gameObject);
            x++;
            if (x > 3)
            {
                x = 0;
                y--;
            }
        }
    }
}
