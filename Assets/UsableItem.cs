using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class UsableItem : Item
{

    public abstract void execute(Vector3Int targetTilePosition);
    public override void useItem()
    {
        Vector3 colliderBottomCenter = GameManager.Instance.player.transform.position;
        if (GameManager.Instance.player.TryGetComponent<BoxCollider2D>(out BoxCollider2D collider))
        {
            colliderBottomCenter = new Vector3(
                collider.bounds.center.x,
                collider.bounds.min.y,
                0 
            );
        }

        Vector3Int playerTilePosition = GameManager.Instance.tileManager.interactive.WorldToCell(colliderBottomCenter);

        Vector3Int targetTilePosition = playerTilePosition;
        switch (GameManager.Instance.player.facingDirection)
        {
            case "left":
                targetTilePosition += new Vector3Int(-1, 0, 0);
                break;
            case "right":
                targetTilePosition += new Vector3Int(1, 0, 0);
                break;
            case "up":
                targetTilePosition += new Vector3Int(0, 1, 0);
                break;
            case "down":
                targetTilePosition += new Vector3Int(0, -1, 0);
                break;
        }

        Debug.Log($"Target tile position: {targetTilePosition}");


        execute(targetTilePosition);
    }
    
}


