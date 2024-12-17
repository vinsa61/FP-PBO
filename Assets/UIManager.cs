using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject upgradePanel;
    public GameObject inventoryPanel2;
    public GameObject shopPanel;
    public GameObject toolbarPanel;
    public static UIManager Instance;
    public GameObject MainMenu;
    public Dictionary<string, Inventory_UI> inventoryUIByName = new Dictionary<string, Inventory_UI>(); 
    public List<Inventory_UI> inventoryUIs;
   
    public Inventory_UI inventoryUI;
  
    public static slot_UI draggedSlot;
    public static Image draggedIcon;
    public static bool dragSingle;

    public bool isToggle = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        Initialize();
        SceneManager.sceneLoaded += OnSceneLoaded; 

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMainMenu();
        }
        dragSingle = Input.GetKey(KeyCode.LeftShift);
    }

    public void ToggleShop()
    {
        inventoryUI.RefreshShop();
        if (inventoryPanel2 != null)
        {
            if (!inventoryPanel2.activeSelf)
            {
                isToggle = true;
                inventoryPanel2.SetActive(true);
                toolbarPanel.SetActive(false);
                RefreshInventoryUI("Backpack");
                RefreshInventory2UI("ShopInventory");
                RefreshInventoryUI("Toolbar");
            }
            else
            {
                isToggle = false;
                inventoryPanel2.SetActive(false);
                toolbarPanel.SetActive(true);
            }
        }

        if (shopPanel != null)
        {
            if (!shopPanel.activeSelf)
            {
                shopPanel.SetActive(true);
                RefreshInventoryUI("Shop");
                RefreshInventory2UI("ShopInventory");
                RefreshInventoryUI("Toolbar");
            }
            else
            {
                shopPanel.SetActive(false);
            }
        }


    }

    public void ToggleUpgrade()
    {
        if (upgradePanel != null)
        {
            if (!upgradePanel.activeSelf)
            {
                isToggle = true;
                upgradePanel.SetActive(true);
            
            }
            else
            {
                isToggle = false;
                upgradePanel.SetActive(false);
            }
        }
    }

    public void ToggleInventory()
    {
        if (inventoryPanel != null)
        {
            if (!inventoryPanel.activeSelf)
            {
                inventoryPanel.SetActive(true);
                RefreshInventoryUI("Backpack");
            }
            else
            {
                inventoryPanel.SetActive(false);
            }
        }


    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; 
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        Initialize();
    }
    public void ToggleMainMenu()
    {
        if (!MainMenu.activeSelf)
        {
            MainMenu.SetActive(true);
        }
        else
        {
            MainMenu.SetActive(false);
        }
    }
    public void RefreshInventoryUI(string inventoryName)
    {
        if (inventoryUIByName.ContainsKey(inventoryName))
        {
            inventoryUIByName[inventoryName].Refresh();
        }
    }

    public void RefreshInventory2UI(string inventoryName)
    {
        if (inventoryUIByName.ContainsKey(inventoryName))
        {
            inventoryUIByName[inventoryName].RefreshShop();
        }
    }


    public void RefreshAll()
    {
        foreach(KeyValuePair<string, Inventory_UI> keyValuePair in inventoryUIByName)
        {
            if (keyValuePair.Key == "ShopInventory")
            {
                keyValuePair.Value.RefreshShop();
            }
            else
            {
                keyValuePair.Value.Refresh();
            }
        }
    }
    public Inventory_UI GetInventoryUI(string inventoryName)
    {
        if (inventoryUIByName.ContainsKey(inventoryName))
        {
            return inventoryUIByName[inventoryName];
        }
        Debug.LogWarning("There is not " + inventoryName);
        return null;
    }

    public void Initialize()
    {
        if (inventoryPanel == null)
            inventoryPanel = GameObject.Find("InventoryPanel");

        if (MainMenu == null)
            MainMenu = GameObject.Find("MainMenu");

        foreach (Inventory_UI ui in inventoryUIs)
        {
            if (!inventoryUIByName.ContainsKey(ui.inventoryName))
            {
                inventoryUIByName.Add(ui.inventoryName, ui);
            }
        }
    }
}
