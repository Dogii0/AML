using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;

public class ItemWorld : MonoBehaviour
{
    private GameObject player;
    private static Vector2 location;
    private void Update()
    {
        location = player.transform.position;
    }
    public static ItemWorld SpawnItemWorld(Vector2 position,Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }
    
    public static ItemWorld DropItem(Item item)
    {
        double random1 = Random.Range(-1, 1);
        double random2 = Random.Range(-1, 1);
        if (random1 > 0 && random2 > 0)
        {
            random1 += 0.5;
            random2 += 0.5;
        } else if (random1 < 0 && random2 > 0)
        {
            random1 -= 0.5;
            random2 += 0.5;
        }else if (random1 < 0 && random2 < 0)
        {
            random1 -= 0.5;
            random2 -= 0.5;
        } else if (random1 > 0 && random2 < 0)
        {
            random1 += 0.5;
            random2 -= 0.5;
        }

        Vector2 dir = new Vector2((float)random1 ,(float)random2);
        ItemWorld itemWorld = SpawnItemWorld(location+ dir,item);
        return itemWorld;
    }
    
    private Item item;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
    }

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }

    public Item GetItem()
    {
        return item;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
