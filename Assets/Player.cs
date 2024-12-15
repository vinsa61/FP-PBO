using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryManager inventory;
    public Toolbar_UI tUI;

    public Item item;
    public int credit;

    public string facingDirection = "right";

    [SerializeField] TMP_Text text;
    [SerializeField] private UIManager uiManager;

    private void Update()
    {

        text.text = "Credit: " + credit.ToString("0000");

        if (uiManager.isToggle == false)
        {
            if (Input.GetKey(KeyCode.A)) 
            {
                facingDirection = "left";
            }
            else if (Input.GetKey(KeyCode.D)) 
            {
                facingDirection = "right";
            }
            else if (Input.GetKey(KeyCode.W)) 
            {
                facingDirection = "up";
            }
            else if (Input.GetKey(KeyCode.S)) 
            {
                facingDirection = "down";
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Vector3 colliderBottomCenter = transform.position;
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
                switch (facingDirection)
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
                if (GameManager.Instance.tileManager.Harvest(targetTilePosition)) {

                
                }
                else
                {
                    item = GameManager.Instance.ItemManager.GetItemByName(tUI.CheckEquip());
                    if (item != null)
                    {
                        item.useItem();
                    }
                }
            }
        }


    }

 
    private void Awake()
    {
        inventory = GetComponent<InventoryManager>();
        credit = 50;
    }



    public void DropItem(Item item)
    {
        Vector3 spawnLocation = transform.position;

        
        Vector3 spawnOffset = Vector3.zero;
        switch (facingDirection)
        {
            case "left":
                spawnOffset = Vector3.left * 1.25f;
                break;
            case "right":
                spawnOffset = Vector3.right * 1.25f;
                break;
            case "up":
                spawnOffset = Vector3.up * 1.25f;
                break;
            case "down":
                spawnOffset = Vector3.down * 1.25f;
                break;
            default:
                spawnOffset = Random.insideUnitCircle * 1.25f; 
                break;
        }

        Item dropItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);

        
        Vector2 forceDirection = spawnOffset.normalized;
        dropItem.rb2d.AddForce(forceDirection * 2f, ForceMode2D.Impulse);
    }


    public void DropItem(Item item, int numToDrop)
    {
       for(int i  = 0; i < numToDrop; i++)
        {
            DropItem(item);
        }

    }
}
