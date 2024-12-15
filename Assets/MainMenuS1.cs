using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuS1 : MonoBehaviour
{
    public GameObject mainMenu;
    public void Return()
    {
        mainMenu.SetActive(false);
    }

    public void ExitToMM()
    {
       SceneManager.LoadScene(0);
    }
}
