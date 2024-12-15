using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public ItemManager ItemManager;
    public TileManager tileManager;
    public UIManager uiManager;
    public Player player;
    public DayTimecontro dayTimeController;
    public CropManager cropManager;


    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

       
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        if (ItemManager == null)
        {
            ItemManager = GetComponent<ItemManager>();
           
        }
            
        if (tileManager == null)
        {
            tileManager = GetComponent<TileManager>();
            GameObject gridObject = GameObject.Find("Grid");

            if (gridObject != null)
            {
                tileManager.interactive = gridObject.transform.Find("Interactive").GetComponent<Tilemap>();
            }
        }
            

        if (uiManager == null)
        {
            uiManager = GetComponent<UIManager>();
            if (uiManager != null)
            {
                DontDestroyOnLoad(uiManager.gameObject);
                uiManager.Initialize();
            }
        }

        if (player == null)
            player = FindObjectOfType<Player>();

        if (dayTimeController == null)
        {
            dayTimeController = GetComponent<DayTimecontro>();
        }

        if(cropManager == null)
        {
            cropManager = GetComponent<CropManager>();
        }
    }


}

