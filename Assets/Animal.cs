using UnityEngine;

public class Animal : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    protected Vector2 direction;
    protected bool canEat = true; 
    protected bool canMove = true; 
    protected int spawnTime;

    protected virtual void Start()
    {
        SetRandomDirection();
        spawnTime = (int)GameManager.Instance.dayTimeController.Hours;
    }

    protected void Move(float movementSpeed)
    {
        if (!canMove) return;

        animator.SetBool("isEating", false); 
        animator.SetBool("isMoving", true); 
        AnimateMovement(direction); 
    }

    protected void SetRandomDirection()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized; 
    }

    protected void Eat()
    {
        if (!canEat) return;

        animator.SetBool("isMoving", false);
        animator.SetBool("isEating", true); 
    }

    public void DropItem(Item item)
    {
        int timeElapsed = (int)GameManager.Instance.dayTimeController.Hours - spawnTime;

        if (timeElapsed < 0)
        {
            timeElapsed += 24; 
        }

        if (timeElapsed >= 6) 
        {
            spawnTime = (spawnTime + 6) % 24;
            Vector3 spawnOffset = Vector3.zero; 

            Item dropItem = Instantiate(item, transform.position + spawnOffset, Quaternion.identity);

            if (dropItem.rb2d != null)
            {
                Vector2 forceDirection = spawnOffset.normalized;
                dropItem.rb2d.AddForce(forceDirection * 2f, ForceMode2D.Impulse);
            }
        }
    }




    protected void AnimateMovement(Vector3 direction)
    {
        if (animator == null) return;

        if (direction.magnitude > 0)
        {
            animator.SetBool("isMoving", true); 
            animator.SetFloat("Horizontal", direction.x); 
            animator.SetFloat("Vertical", direction.y);
        }
        else
        {
            animator.SetBool("Moving", false); 
        }
    }
}
