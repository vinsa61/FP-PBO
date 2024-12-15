using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropSeed : UsableItem
{
    [SerializeField] public Crops c;
    public override void execute(Vector3Int targetTilePosition)
    {
        Debug.Log("AA");
        if (GameManager.Instance.tileManager.isPlowed(targetTilePosition))
        {
            Debug.Log("BISA");
            GameManager.Instance.tileManager.Seed(targetTilePosition, c.cropdata.cropName);
                GameManager.Instance.player.inventory.toolbar.Remove(GameManager.Instance.player.tUI.CheckIndex());
                UIManager.Instance.RefreshAll();

        }

    }
}
