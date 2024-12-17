using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Animal : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    protected Vector2 direction;
    protected bool canEat = true; 
    protected bool canMove = true; 
    protected int spawnTime;
    protected float movementSpeed = 0;
    protected bool wasEat = false;
    protected bool isEatingS = false;
    

    public void SetSpeed(float value)
    {
        movementSpeed = value;
    }


    protected virtual void Start()
    {
        SetRandomDirection();
        spawnTime = (int)GameManager.Instance.dayTimeController.Hours;
        StartCoroutine(RandomBehaviorCoroutine());
    }

    private IEnumerator RandomBehaviorCoroutine()
    {
        while (true)
        {
            float waitTime = 0;
            int randomAction;

            if (wasEat)
            {
                randomAction = Random.Range(0, 2);
            }
            else
            {
                randomAction = Random.Range(0, 3);
            }

            if (randomAction == 0)
            {
                Idle();
                wasEat = false;
                waitTime = Random.Range(1f, 2f);
            }
            else if (randomAction == 1)
            {
                animator.SetBool("isMoving", true);
                SetRandomDirection();
                for (float timer = 0; timer < Random.Range(2f, 5f); timer += Time.deltaTime)
                {
                    Move(movementSpeed);
                    this.transform.position += (Vector3)direction.normalized * movementSpeed * Time.deltaTime;
                    wasEat=false;
                    yield return null;
                }
            }
            else if (randomAction == 2)
            {
                Eat();
                wasEat = true;
                waitTime = Random.Range(2f, 3f);



            }

            
            yield return new WaitForSeconds(waitTime);
            if (wasEat)
            {
                animator.SetBool("isEating", false);
                waitTime = 1f;
                yield return new WaitForSeconds(waitTime);
            }
           
            isEatingS = false;

            animator.SetBool("isMoving", false);
            animator.SetBool("isEating", false);
        }
    }


    private void Idle()
    {
        animator.SetBool("isMoving", false);
        animator.SetBool("isEating", false);
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
        isEatingS = true;



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
