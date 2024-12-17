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
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Jangan hancurkan semua manager jika ada
            if (ItemManager != null)
                DontDestroyOnLoad(ItemManager.gameObject);

            if (tileManager != null)
                DontDestroyOnLoad(tileManager.gameObject);

            if (uiManager != null)
                DontDestroyOnLoad(uiManager.gameObject);

            if (player != null)
                DontDestroyOnLoad(player.gameObject);

            if (dayTimeController != null)
                DontDestroyOnLoad(dayTimeController.gameObject);

            if (cropManager != null)
                DontDestroyOnLoad(cropManager.gameObject);

            // Tambahkan listener untuk scene change
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Cek jika scene adalah MainMenu
        if (scene.name == "MainMenu")
        {
            SetManagersActive(false); // Nonaktifkan semua manager
        }
        else if (scene.name == "GameScene")
        {
            SetManagersActive(true); // Aktifkan semua manager
        }
    }

    private void SetManagersActive(bool state)
    {
        if (ItemManager != null)
            ItemManager.gameObject.SetActive(state);

        if (tileManager != null)
            tileManager.gameObject.SetActive(state);

        if (uiManager != null)
            uiManager.gameObject.SetActive(state);

        if (player != null)
            player.gameObject.SetActive(state);

        if (dayTimeController != null)
            dayTimeController.gameObject.SetActive(state);

        if (cropManager != null)
            cropManager.gameObject.SetActive(state);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; 
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

