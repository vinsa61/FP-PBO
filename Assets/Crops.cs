using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;


public class Crops : MonoBehaviour
{
    public CropData cropdata;
    public Item harvested;
    public int randomInt;
    public void DropItem(Vector3 spawnlocation)
    {
        randomInt = Random.Range(1, 4);

        Vector3 spawnOffset = Vector3.zero;
        switch (randomInt)
        {
            case 1:
                spawnOffset = Vector3.left * 1.25f;
                break;
            case 2:
                spawnOffset = Vector3.right * 1.25f;
                break;
            case 3:
                spawnOffset = Vector3.up * 1.25f;
                break;
            case 4:
                spawnOffset = Vector3.down * 1.25f;
                break;
            default:
                spawnOffset = Random.insideUnitCircle * 1.25f;
                break;
        }

        Item dropItem = Instantiate(harvested, spawnlocation + spawnOffset, Quaternion.identity);

        Vector2 forceDirection = spawnOffset.normalized;
        dropItem.rb2d.AddForce(forceDirection * 2f, ForceMode2D.Impulse);
    }

}