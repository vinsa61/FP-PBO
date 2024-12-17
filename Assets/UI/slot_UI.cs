using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using static Inventory;

public class slot_UI : MonoBehaviour
{

    public int slotID;
    public Inventory inventory;
    public Image itemicon;
    public TextMeshProUGUI quantity;

    [SerializeField] private GameObject highlight;

    public void SetItem(Inventory.Slot slot)
    {
        if (slot.itemName != null)
        {
            Debug.Log($"Assigning sprite: {slot.icon}");
            itemicon.sprite = slot.icon;
            itemicon.color = new Color(1, 1, 1, 1);
            quantity.text = slot.count.ToString();
        }
        else
        {
            Debug.LogError($"Slot {slotID} does not have a valid icon.");
        }
    }

    public void AddShopItem(Inventory.Slot slot)
    {
        if (slot.itemName != null)
        {
            itemicon.sprite = slot.icon;
            itemicon.color = new Color(1, 1, 1, 1);
            quantity.text = "";
        } 
        else
        {
            Debug.LogError($"Set Item Failed.");
        }
    }
    public void SetEmpty()
    {
        itemicon.sprite = null;
        itemicon.color = new Color(1, 1, 1, 0);
        quantity.text = "";
    }

    public void setHighlight(bool isOn)
    {
        highlight.SetActive(isOn);

    }

    public bool cekHighlight()
    {
        if (highlight.activeInHierarchy)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    if (eventData.button == PointerEventData.InputButton.Left)
    //    {
    //        GameManager.Instance.uiManager.inventoryUI.Sell(this);
    //    }
    //}
}
