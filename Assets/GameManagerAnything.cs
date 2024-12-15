using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerAnything : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
