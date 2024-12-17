using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public Dictionary<string, Inventory> inventoryByName = new Dictionary<string, Inventory>();

    [Header("Backpack")]
    public Inventory backpack;
    public int backpackSlotCount;

    [Header("Toolbar")]
    public Inventory toolbar;
    public int toolbarSlotCount;
    
    [Header("ShopList")]
    public Inventory shopList;
    public int shopSlotCount;
    private void Awake()
    {
        backpack = new Inventory(backpackSlotCount);
        toolbar = new Inventory(toolbarSlotCount);
        shopList = new Inventory(shopSlotCount);

        //Debug.Log($"Toolbar Slot: {toolbarSlotCount}");
        inventoryByName.Add("Backpack", backpack);
        inventoryByName.Add("Toolbar", toolbar);
        inventoryByName.Add("ShopList", shopList);
    }

    public void Add(string name, Item item)
    {
        if (inventoryByName.ContainsKey(name))
        {
            inventoryByName[name].Add(item);
        }
    }

    public Inventory GetInventorybyName(string name)
    {
        if (inventoryByName.ContainsKey(name))
        {
            return inventoryByName[name];   
        }
        return null;
    }
}
