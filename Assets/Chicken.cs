
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Animal
{
    public float movementSpeed = 2f;
    public Item item;
    public bool gender;
    float lastX;
    float lastY;
    protected override void Start()
    {
        base.Start();
        StartCoroutine(RandomBehaviorCoroutine());
    }

    private IEnumerator RandomBehaviorCoroutine()
    {
        while (true)
        {
            float waitTime = 0;
            int randomAction = Random.Range(0, 3); 

            if (randomAction == 0) 
            {
                Idle();
                waitTime = Random.Range(2f, 3f);
            }
            else if (randomAction == 1) 
            {
                animator.SetBool("isMoving", true);
                SetRandomDirection();
                for (float timer = 0; timer < Random.Range(2f, 4f); timer += Time.deltaTime)
                {
                    Move(movementSpeed); 
                    this.transform.position += (Vector3)direction.normalized * movementSpeed * Time.deltaTime;
                    yield return null; 
                }
            }
            else if (randomAction == 2) 
            {
                Eat();
                waitTime = Random.Range(1f, 1f);
            }


            yield return new WaitForSeconds(waitTime);

            animator.SetBool("isMoving", false);
            animator.SetBool("isEating", false);
        }
    }


    private void Idle()
    {
        animator.SetBool("isMoving", false);
        animator.SetBool("isEating", false);
    }


    private void Update()
    {
        DropItem(item);
    }


}

