using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  Hoe : UsableItem
{ 
    public override void execute(Vector3Int targetTilePosition)
    {
        Debug.Log("AA");
        if (GameManager.Instance.tileManager.isInteractable(targetTilePosition))
        {
            Debug.Log("BISA");
            GameManager.Instance.tileManager.Plow(targetTilePosition);
        }
       
    }
}
