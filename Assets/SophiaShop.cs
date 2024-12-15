using UnityEngine;

public class Sophia : MonoBehaviour
{
    private bool isPlayerInRange = false;

    private void Update()
    {
        //Debug.Log(isPlayerInRange);
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            ToggleShop();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void ToggleShop()
    {
        GameManager.Instance.uiManager.ToggleShop(); 
    }
}
