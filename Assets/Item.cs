using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    public ItemData data;

    [HideInInspector] public Rigidbody2D rb2d;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public virtual void useItem()
    {

    }
}
