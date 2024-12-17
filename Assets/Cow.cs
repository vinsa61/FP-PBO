
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cow : Animal
{
    public float milkCooldown = 5f; // Cooldown in hours
    private float lastMilkTime = -10f; // Last time the cow was milked
    private bool isPlayerInInteractionArea = false; // Track if player is in interaction area
    [SerializeField]  private BoxCollider2D cowCollider; // The collider that is the physical boundary of the cow
    [SerializeField]  private BoxCollider2D interactionArea;
  
    public Item item;
    public bool gender = false;

 



    protected override void Start()
    {
        SetSpeed(1f);
        base.Start();
       
     
    }



    private void Update()
    {
        if (isEatingS)
        {
            cowCollider.offset = new Vector2(0.02f, -0.52f);
            cowCollider.size = new Vector2(1.19f, 1f);
        }else if (Mathf.Abs(direction.x)  < Mathf.Abs(direction.y) || ((!(animator.GetBool("isEating")) && wasEat)))
        {
            cowCollider.offset = new Vector2(0.02f, -0.15f);
            cowCollider.size = new Vector2(1.15f, 1.47f);
        }
        else if(direction.x > 0)
        {

            cowCollider.offset = new Vector2(0.15f, -0.36f);
            cowCollider.size = new Vector2(1.71f, 1.09f);
        }
        else if (direction.x < 0)
        {
            cowCollider.offset = new Vector2(-0.15f, -0.36f);
            cowCollider.size = new Vector2(1.71f, 1.09f);
        }


        if (isPlayerInInteractionArea && Input.GetKeyDown(KeyCode.E) && !gender)
        {
            Milked();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            isPlayerInInteractionArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Player exits the interaction area
        if (other.CompareTag("Player"))
        {
            isPlayerInInteractionArea = false;
        }
    }

    private void Milked()
    {
        // Calculate the time difference in hours since the last milking
        float timeSinceLastMilk = GameManager.Instance.dayTimeController.Hours - lastMilkTime;

        // If enough time has passed (cooldown is over), milk the cow
        if (timeSinceLastMilk >= milkCooldown)
        {
            // Milk the cow
            Debug.Log("Cow has been milked!");
            DropItem(item);

            // Update the last milking time to the current time
            lastMilkTime = GameManager.Instance.dayTimeController.Hours;

            // You can also add logic for giving the player some milk items or rewards here
        }
        else
        {
            // Notify the player that the cooldown is still active
            Debug.Log("Cow is still on cooldown. Please wait for " + (milkCooldown - timeSinceLastMilk) + " hours.");
        }
    }

}

