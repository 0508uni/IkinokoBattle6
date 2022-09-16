using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class OwnedItemsData
{
    // Start is called before the first frame update

    private const string PlayerPrefskey = "OWNED_ITEMS_DATA";

    public static OwnedItemsData Instance
    {
        get
        {
            if (null == Instance)
            {
                _instance = PlayerPrefs.HasKey(PlayerPrefskey) ? JsonUtility.FromJson<OwnedItemsData>(PlayerPrefs.GetString(PlayerPrefskey)) : new OwnedItemsData();
            }

            return _instance;
        }
    }

    private static OwnedItemsData _instance;

    public OwnedItem[] OwnedItems
    {
        get { return OwnedItems.ToArray(); }
    }

    [SerializeField] private List<OwnedItem> ownedItems = new List<OwnedItem>();

    private OwnedItemsData()
    {
    }

    public void Save()
    {
        var jsonString = JsonUtility.ToJson(this);
        PlayerPrefs.SetString(PlayerPrefskey, jsonString);
        PlayerPrefs.Save();
    }

    public void Add(Item.ItemType type,int number = 1)
    {
        var item = GetItem(type);
        if(null == item)
        {
            item = new OwnedItem(type);
            ownedItems.Add(item);
        }
        item.Add(number);
    }

    public void Use(Item.ItemType type,int number = 1)
    {
        var item = GetItem(type);
        if(null == item || item.Number < number)
        {
            throw new Exception("アイテムが足りません");
        }
        item.Use(number);
    }

    public OwnedItem GetItem(Item.ItemType type)
    {
        return ownedItems.FirstOrDefault(x => x.Type == type);
    }

    [Serializable]
    public class OwnedItem
    {
        public Item.ItemType Type
        {
            get { return type; }
        }
        public int Number
        {
            get { return number; }
        }

        [SerializeField] private Item.ItemType type;

        [SerializeField] private int number;

        public OwnedItem(Item.ItemType type)
        {
            this.type = type;
        }
        public void Add(int number = 1)
        {
            this.number += number;
        }
        public void Use(int number = 1)
        {
            this.number -= number;
        }
    }
}