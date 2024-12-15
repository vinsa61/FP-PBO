using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Animal
{
    public Item item;

    public void Update()
    {
        DropItem(item);
        if (true)
        {
            Eat();
            animator.SetBool("isMoving", false);
        }
        else
        {
            Move(3f);
            animator.SetBool("isMoving", true);
        }

        animator.SetBool("isEating", true);

        animator.SetFloat("horizontal", direction.x);
        animator.SetFloat("vertical", direction.y);


    }

}
