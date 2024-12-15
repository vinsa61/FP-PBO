using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    public void Interact()
    {
        SceneManager.LoadScene(2);
    }
}
