using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        public string itemName;
        public int count;
        public int max;
        public Sprite icon;
        public Slot()
        {
            itemName = "";
            count = 0;
            max = 16;
        }

        public bool IsEmpty
        {

            get
            {
                if (itemName == "" && count == 0)
                {
                    return true;
                }
                return false;

            }

        }
        public bool Cek(string itemName)
        {
            if (count < max && this.itemName == itemName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddItem(Item item)
        {
            this.itemName = item.data.itemName;
            this.icon = item.data.icon;
            count++;
        }

        public void AddItem(string ItemName, Sprite icon, int max)
        {
            this.itemName = ItemName;
            this.icon = icon;
            count++;
            this.max = max;
        }
        public void RemoveItem()
        {
            if(count > 0)
            {
                count--;
                if(count == 0)
                {
                    icon = null;
                    itemName = "";   
                }
            }
        }  
    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int num)
    {
        for (int i = 0; i < num; i++)
        {
            slots.Add(new Slot());
        }
        //Debug.Log($"its over {slots.Count}");
    }

    public void Add(Item itemAdd)
    {
        foreach(Slot slot in slots)
        {
            if(slot.itemName == itemAdd.data.itemName && slot.Cek(itemAdd.data.itemName))
            {
                slot.AddItem(itemAdd);
                return;
            }
        }
        foreach(Slot slot in slots)
        {
            if(slot.itemName == "")
            {
                slot.AddItem(itemAdd); 
    
                return ;
            }
        }
    }

    public void AddShop(Item itemAdd)
    {

        foreach (Slot slot in slots)
        {
            if (slot.itemName == "")
            {
                slot.AddItem(itemAdd);
                return;
            }
        }
    }

    public bool AddCheck(Item itemAdd)
    {
        foreach(Slot slot in slots)
        {
            if(slot.itemName == itemAdd.data.itemName && slot.Cek(itemAdd.data.itemName))
            {
                slot.AddItem(itemAdd);
                return true;
            }
        }
        foreach(Slot slot in slots)
        {
            if(slot.itemName == "")
            {
                slot.AddItem(itemAdd);    
                return true;
            }
        }
        return false;
    }

    public void Remove(int index)
    {
        if (index >= 0 && index < slots.Count)
        {
            slots[index].RemoveItem();
        }

    }

    public void Remove(int index, int numToRemove)
    {
        if (slots[index].count >= numToRemove)
        {
            for(int i = 0; i < slots.Count; i++) {
                Remove(index);
            }
        }

    }

    public void MoveSlot(int fromIndex, int toIndex, Inventory toInventory, int num = 1)
    {
        Slot fromSlot = slots[fromIndex];
        Slot toSlot = toInventory.slots[toIndex];

        if(toSlot.IsEmpty || toSlot.Cek(fromSlot.itemName))
        {
            for (int i = 0; i < num; i++)
            {
                toSlot.AddItem(fromSlot.itemName, fromSlot.icon, fromSlot.max);
                fromSlot.RemoveItem();
            }
        }
    }
}
