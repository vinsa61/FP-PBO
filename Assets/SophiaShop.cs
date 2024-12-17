using UnityEngine;

public class Sophia : MonoBehaviour
{
    private bool isPlayerInRangeofSophia = false;

    private void Update()
    {
        if (isPlayerInRangeofSophia && Input.GetKeyDown(KeyCode.Space))
        {
            ToggleShop();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRangeofSophia = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRangeofSophia = false;
        }
    }

    private void ToggleShop()
    {
        GameManager.Instance.uiManager.ToggleShop(); 
    }
}
