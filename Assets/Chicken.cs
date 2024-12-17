
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Animal
{

    public Item item;
    public bool gender = false;
    float lastX;
    float lastY;

    protected override void Start()
    {
        SetSpeed(2f);
        base.Start();
    }


    private void Update()
    {
        if (!(gender)){
            DropItem(item);

        }
    }


}

