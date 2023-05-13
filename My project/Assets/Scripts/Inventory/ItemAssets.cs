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
        // DontDestroyOnLoad(this.gameObject);
    }

    public Transform pfItemWorld;

    public Sprite weaponSprite;
    public Sprite foodSprite;
    public Sprite coinSprite;
    public Sprite treeSprite;
}
