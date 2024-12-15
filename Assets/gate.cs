using UnityEngine;
using UnityEngine.Tilemaps;


public class Gate : MonoBehaviour
{
    

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    if ((GameManager.Instance.player.GetComponent<SpriteRenderer>().transform.position.y - 6) > GameManager.Instance.tileManager.interactive3.GetComponent<TilemapRenderer>().transform.position.y)
            //    {
            //        Vector3 newPosition = other.transform.position;
            //        newPosition.y = 5;
            //        other.transform.position = newPosition;
            //    }
            //    else
            //    {
            //        Vector3 newPosition = other.transform.position;
            //        newPosition.y = 7;
            //        other.transform.position = newPosition;
            //    }
                


            //}
        }
    }
}