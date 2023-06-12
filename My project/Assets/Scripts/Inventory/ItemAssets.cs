using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public Transform pfItemWorld;

    public Sprite coinSprite;
    public Sprite treeSprite;
    public Sprite umbrellaSprite;
    public Sprite fireExtSprite;
    public Sprite kimbapSprite;
    public Sprite samgakSprite;
    public Sprite milkSprite;
}
