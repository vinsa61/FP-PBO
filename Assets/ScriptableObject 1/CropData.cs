using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Crop Data", menuName = "Crop Data", order = 50)]
public class CropData : ScriptableObject
{
    public string cropName = "Crop Name";

    [SerializeField] public Tile State1;
    [SerializeField] public Tile State2;
    [SerializeField] public Tile State3;
    [SerializeField] public Tile State4;
    [SerializeField] public Tile State5;
    [SerializeField] public Tile State6;
    [SerializeField] public Tile State7;
}

