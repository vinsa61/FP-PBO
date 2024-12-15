using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Toolbar_UI : MonoBehaviour
{
    [SerializeField] private List<slot_UI> toolbarSlots = new List<slot_UI>();

    private slot_UI selectedSlot;

    private void Start()
    {
        SelectSlot(0);
    }
    private void Update()
    {
        CheckAlpha();
    }
    public void SelectSlot(int index)
    {
        //Debug.Log($"Hebat {toolbarSlots.Count}");
        if (toolbarSlots.Count == 10)
        {
            if (selectedSlot != null)
            {
                selectedSlot.setHighlight(false);
            }
            selectedSlot = toolbarSlots[index];
            selectedSlot.setHighlight(true);
        }
    }

    public string CheckEquip()
    {
        for (int i = 0; i < 9; i++) {
            if (toolbarSlots[i] != null && toolbarSlots[i].cekHighlight())
            {
                    Debug.Log($"HEY: {toolbarSlots[i]} {i}");
                    return toolbarSlots[i].inventory.slots[i].itemName;

            }
        }
        return "null";

    }

    public int CheckIndex()
    {
        for (int i = 0; i < 9; i++)
        {
            if (toolbarSlots[i] != null && toolbarSlots[i].cekHighlight())
            {
                Debug.Log($"HEY: {toolbarSlots[i]} {i}");
                return i;

            }
        }
        return -1;

    }

    private void CheckAlpha()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSlot(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectSlot(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SelectSlot(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SelectSlot(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SelectSlot(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SelectSlot(8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SelectSlot(9);
        }
    }
}
