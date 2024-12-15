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
    private void Awake()
    {
        backpack = new Inventory(backpackSlotCount);
        toolbar = new Inventory(toolbarSlotCount);

        //Debug.Log($"Toolbar Slot: {toolbarSlotCount}");
        inventoryByName.Add("Backpack", backpack);
        inventoryByName.Add("Toolbar", toolbar);
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
