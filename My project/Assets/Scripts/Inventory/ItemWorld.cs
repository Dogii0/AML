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
        Vector2 dir = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
        ItemWorld itemWorld = SpawnItemWorld(location+dir,item);
        // itemWorld.GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);
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
