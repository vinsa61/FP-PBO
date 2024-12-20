using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Item[] items;
    public Dictionary<string, Item> nameToItemDict { get; private set; } = new Dictionary<string, Item>();

    private void Awake()
    {
        foreach(Item c in items)
        {
            AddItem(c); 
        }  
    }

    private void AddItem(Item item)
    {
        if (!nameToItemDict.ContainsKey(item.data.itemName))
        {
            nameToItemDict.Add(item.data.itemName, item);
        }
    }
    public Item GetItemByName(string key)
    {
        if (nameToItemDict.ContainsKey(key))
        {
            return nameToItemDict[key];
        }
        return null;
    }

}
