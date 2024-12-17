using UnityEngine;

public class Pierre : MonoBehaviour
{
    private bool isPlayerInRangeofPierre = false;

    private void Update()
    {
        if (isPlayerInRangeofPierre && Input.GetKeyDown(KeyCode.Space))
        {
            ToggleUpgrade();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRangeofPierre = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRangeofPierre = false;
        }
    }

    private void ToggleUpgrade()
    {
        GameManager.Instance.uiManager.ToggleUpgrade();
    }
}
