using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.Progress;


public class CropManager : MonoBehaviour
{
    public Crops[] crop;
    public Dictionary<string, List<Tile>> CropListState {  get; private set; } = new Dictionary<string, List<Tile>>();
    public Dictionary<string, Crops> cropDict { get; private set; } = new Dictionary<string, Crops>();

    private void Awake()
    {
        foreach(Crops c in crop)
        {
            AddCrop(c); 
        }  
    }

    private void AddCrop( Crops crop)
    {
        if (!CropListState.ContainsKey(crop.cropdata.cropName))
        {
            List<Tile> buffer = new List<Tile>
                {
                    crop.cropdata.State1,
                    crop.cropdata.State2,
                    crop.cropdata.State3,
                    crop.cropdata.State4,
                    crop.cropdata.State5,
                    crop.cropdata.State6,
                    crop.cropdata.State7
                };
            CropListState[crop.cropdata.cropName] = buffer;
            cropDict.Add(crop.cropdata.cropName, crop);
        }
    }
    public Tile GetFirstTile(string key)
    {
        if (CropListState.ContainsKey(key))
        {
            return CropListState[key][0];
        }
        return null;
    }


    public Crops GetCropByName(string key)
    {
        if (cropDict.ContainsKey(key))
        {
            return cropDict[key];
        }
        return null;
    }
}
