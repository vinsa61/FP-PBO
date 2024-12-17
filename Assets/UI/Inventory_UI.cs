using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using static Inventory;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Inventory_UI : MonoBehaviour
{
    
    public string inventoryName;
    public List<slot_UI> slots = new List<slot_UI>();
    [SerializeField] private Canvas canvas;

    private Inventory inventory;
    private Inventory backpackInventory;
    private Inventory toolbarInventory;
    private Inventory shopList;

    private void Awake()
    {   
        canvas = FindObjectOfType<Canvas>();
    }
 

   private void Start()
    {
        if (inventoryName == "ShopInventory")
        {
            backpackInventory = GameManager.Instance.player.inventory.GetInventorybyName("Backpack");
            toolbarInventory = GameManager.Instance.player.inventory.GetInventorybyName("Toolbar");

            SetupSlotsShop(backpackInventory, 0, 25);
            SetupSlotsShop(toolbarInventory, 25, 10);
            RefreshShop();
        } else if (inventoryName == "ShopList")
        {
            shopList = GameManager.Instance.player.inventory.GetInventorybyName("ShopList");
            SetupSlots();
  
            foreach (var item in GameManager.Instance.ItemManager.items)
            {
                if(item.data.price == 0)
                {
                    continue;
                }
                shopList.AddShop(item);
                
            }

            RefreshShopList();
        }
        else
        {
            inventory = GameManager.Instance.player.inventory.GetInventorybyName(inventoryName);
            SetupSlots();
            Refresh();
        }

}

    public void Refresh()
    {
        if (inventoryName == "ShopInventory" || inventoryName == "ShopList")
        {
            Debug.Log("Skipping Refresh.");
            return;
        }

        if (inventory == null)
        {
            Debug.LogError($"Inventory is null for {inventoryName}. Make sure it's assigned correctly.");
            return;
        }

        if (inventory.slots == null || slots == null)
        {
            Debug.LogError($"Slots list or inventory slots are null for {inventoryName}.");
            return;
        }
        //Debug.Log($"HEY {inventory.slots.Count}, {slots.Count}");
        if (inventory.slots.Count == slots.Count)
        {
            //Debug.Log($"Gedi inventory UI for {inventoryName}");
            for (int i = 0; i < slots.Count; i++)
            {
                if (inventory.slots[i].itemName != "")
                {
                    slots[i].SetItem(inventory.slots[i]);

                    Canvas.ForceUpdateCanvases();
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

    public void RefreshShop()
    {
        // Backpack (25 slots)
        if (backpackInventory.slots.Count != 25)
        {
            Debug.LogError("Backpack inventory size mismatch.");
            return;
        }

        // Toolbar (10 slots)
        if (toolbarInventory.slots.Count != 10)
        {
            Debug.LogError("Toolbar inventory size mismatch.");
            return;
        }
        //for (int i = 0; i < backpackInventory.slots.Count; i++)
        //{
        //    Debug.Log($"Backpack Slot {i}: {backpackInventory.slots[i].itemName}, Count: {backpackInventory.slots[i].count}");
        //}
        //for (int i = 0; i < toolbarInventory.slots.Count; i++)
        //{
        //    Debug.Log($"Toolbar Slot {i}: {toolbarInventory.slots[i].itemName}, Count: {toolbarInventory.slots[i].count}");
        //}

        // Update Toolbar UI
        for (int i = 0; i < 10; i++)
        {
            if (toolbarInventory.slots[i].itemName != "")
            {
                slots[25 + i].SetItem(toolbarInventory.slots[i]);
            }
            else
            {
                slots[25 + i].SetEmpty();
            }
        }
        // Update Backpack UI
        for (int i = 0; i < 25; i++)
        {
            if (backpackInventory.slots[i].itemName != "")
            {
                slots[i].SetItem(backpackInventory.slots[i]);
            }
            else
            {
                slots[i].SetEmpty();
            }
        }

    }
    public void RefreshShopList()
    {
        if (shopList.slots.Count != 35)
        {
            Debug.LogError("Shop List size mismatch.");
            return;
        }

        // Update Shop List UI
        for (int i = 0; i < 35; i++)
        {


            if (shopList.slots[i].itemName != "")
            {
                slots[i].AddShopItem(shopList.slots[i]);
           
                Canvas.ForceUpdateCanvases();
            }
            else
            {
                slots[i].SetEmpty();
            }
            //shopList.Add(GameManager.Instance.ItemManager.GetItemByName("StrawberryFruit"));
            
        }
    }

    public void Sell(slot_UI slot)
    {
        if (slot == null || slot.inventory == null)
        {
            Debug.LogError("Slot or inventory is invalid.");
            return;
        }

        var targetSlot = slot.inventory.slots[slot.slotID];

        if (targetSlot != null && targetSlot.count > 0)
        {
            Item soldItem = GameManager.Instance.ItemManager.GetItemByName(targetSlot.itemName);
            Debug.Log(targetSlot.itemName);
            if(soldItem.data.price > 0)
            {
                //Debug.Log(soldItem.data.price);
                targetSlot.RemoveItem();

                GameManager.Instance.player.credit += soldItem.data.price;
                UIManager.Instance.RefreshInventoryUI("Backpack");
                UIManager.Instance.RefreshInventory2UI("ShopInventory");
                Debug.Log(inventoryName);
                if (inventoryName == "ShopInventory")
                {
                    Debug.Log("Refresh Shop");
                    RefreshShop();
                } else
                {
                    Refresh();
                }

                //Debug.Log($"Sold 1 {targetSlot.itemName}. Remaining count: {targetSlot.count}");
            }
        }
        else
        {
            Debug.LogWarning("No item to sell or item count is already zero.");
        }
    }

    public void Buy(slot_UI slot)
    {
        if(inventoryName != "ShopList")
        {
            return;
        }

        Debug.LogWarning($"{slot.slotID}");

        if (shopList.slots[slot.slotID].IsEmpty)
        {
            Debug.LogError("Invalid slot or inventory during purchase.");
            return;
        }

     
        var shopSlot = shopList.slots[slot.slotID];

        Debug.LogWarning($"{slot.slotID}");

        if (shopSlot == null || string.IsNullOrEmpty(shopSlot.itemName))
        {
            Debug.LogWarning("No item to buy in this slot.");
            return;
        }


        Item itemToBuy = GameManager.Instance.ItemManager.GetItemByName(shopSlot.itemName);
        if (itemToBuy == null)
        {
            Debug.LogError("Item not found in the database.");
            return;
        }


        int itemPrice = itemToBuy.data.price;
        if (GameManager.Instance.player.credit < itemPrice)
        {
            Debug.LogWarning("Not enough credits to buy this item.");
            return;
        }

        Inventory backpack = GameManager.Instance.player.inventory.GetInventorybyName("Backpack");
        bool added = backpack.AddCheck(itemToBuy);

        if (added)
        {
            GameManager.Instance.player.credit -= itemPrice;

            Debug.Log($"Bought {itemToBuy.data.name} for {itemPrice} credits.");

            UIManager.Instance.RefreshInventoryUI("Backpack");
            UIManager.Instance.RefreshInventory2UI("ShopInventory");
      

        }
        else
        {
            Debug.LogWarning("Backpack is full. Cannot add the item.");
        }
    }


    public void Remove()
    {
        Item dropItem = GameManager.Instance.ItemManager.GetItemByName(inventory.slots[UIManager.draggedSlot.slotID].itemName);
        if (dropItem != null)
        {
            Debug.Log(UIManager.dragSingle);
            if (UIManager.dragSingle)
            {
                GameManager.Instance.player.DropItem(dropItem);
                inventory.Remove(UIManager.draggedSlot.slotID);
            }
            else
            {
                GameManager.Instance.player.DropItem(dropItem, inventory.slots[UIManager.draggedSlot.slotID].count);
                inventory.Remove(UIManager.draggedSlot.slotID, inventory.slots[UIManager.draggedSlot.slotID].count);
            }
            Refresh();

        }

        UIManager.draggedSlot = null;

    }

    public void SlotBeginDrag(slot_UI slot)
    {
        UIManager.draggedSlot = slot;
        UIManager.draggedIcon = Instantiate(slot.itemicon);
        UIManager.draggedIcon.transform.SetParent(canvas.transform);
        UIManager.draggedIcon.raycastTarget = false;
        UIManager.draggedIcon.rectTransform.sizeDelta = new Vector2(30, 30);

        MoveToMousePos(UIManager.draggedIcon.gameObject);
        //Debug.Log("Start Drag: " + UIManager.draggedSlot.name);
    }

    public void SlotDrag()
    {
        MoveToMousePos(UIManager.draggedIcon.gameObject);
        //Debug.Log("Dragging " + UIManager.draggedSlot.name);
    }

    public void SlotEndDrag()
    {
        Destroy(UIManager.draggedIcon.gameObject);
        UIManager.draggedIcon = null;
        //Debug.Log("Dragging Done ");
    }

    public void SlotDrop(slot_UI slot)
    {
        Debug.Log(UIManager.dragSingle);
        if (UIManager.dragSingle)
        {
            Debug.Log("Dropped " + UIManager.draggedSlot.name + " on " + slot.name);

            if (inventoryName == "ShopInventory" && slot.slotID > 25)
            {
                UIManager.draggedSlot.inventory.MoveSlot(UIManager.draggedSlot.slotID, (slot.slotID - 25) , slot.inventory);
            }
            else
            {
                UIManager.draggedSlot.inventory.MoveSlot(UIManager.draggedSlot.slotID, slot.slotID, slot.inventory);
            }
            


        }
        else
        {
            Debug.Log("Dropped " + UIManager.draggedSlot.name + " on " + slot.name);

            if (inventoryName == "ShopInventory" && slot.slotID > 25)
            {
                UIManager.draggedSlot.inventory.MoveSlot(UIManager.draggedSlot.slotID, (slot.slotID - 25), slot.inventory, (UIManager.draggedSlot.inventory.slots[UIManager.draggedSlot.slotID].count + 10));
            }
            else
            {
                UIManager.draggedSlot.inventory.MoveSlot(UIManager.draggedSlot.slotID, slot.slotID, slot.inventory, UIManager.draggedSlot.inventory.slots[UIManager.draggedSlot.slotID].count);
            }

        }

        GameManager.Instance.uiManager.RefreshAll();
    }

    private void MoveToMousePos(GameObject toMove)
    {
        if (canvas != null)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);
            toMove.transform.position = canvas.transform.TransformPoint(position);
        }
    }

    void SetupSlots()
    {
        int counter = 0;
        foreach (slot_UI slot in slots)
        {
            slot.slotID = counter;
            counter++;
            slot.inventory = inventory;
        }

    }


    void SetupSlotsShop(Inventory targetInventory, int startIndex, int slotCount)
    {
        for (int i = 0; i < slotCount; i++)
        {
            slots[startIndex + i].slotID = i;
            slots[startIndex + i].inventory = targetInventory;
        }
    }

    void SetupSlotsShopList()
    {
        int counter = 0;
        foreach (slot_UI slot in slots)
        {
            slot.slotID = counter;
            counter++;
            slot.inventory = inventory;
        }
        counter = 0;

    }
}
