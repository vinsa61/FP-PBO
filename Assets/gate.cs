using UnityEngine;
using UnityEngine.Tilemaps;


public class Gate : MonoBehaviour
{
    [SerializeField] Tilemap tile;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(GameManager.Instance.player.transform.position.x >= 21)
                {
                    if ((GameManager.Instance.player.GetComponent<SpriteRenderer>().transform.position.y - 2) > tile.GetComponent<TilemapRenderer>().transform.position.y)
                    {
                        Vector3 newPosition = other.transform.position;
                        newPosition.y = 1;
                        other.transform.position = newPosition;
                    }
                    else
                    {
                        Vector3 newPosition = other.transform.position;
                        newPosition.y = 3;
                        other.transform.position = newPosition;
                    }
                }
                else
                {
                    if ((GameManager.Instance.player.GetComponent<SpriteRenderer>().transform.position.y - 6) > tile.GetComponent<TilemapRenderer>().transform.position.y)
                    {
                        Vector3 newPosition = other.transform.position;
                        newPosition.y = 5;
                        other.transform.position = newPosition;
                    }
                    else
                    {
                        Vector3 newPosition = other.transform.position;
                        newPosition.y = 7;
                        other.transform.position = newPosition;
                    }
                }
                
                


            }
        }
    }
}