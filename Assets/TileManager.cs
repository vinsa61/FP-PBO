using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using static UnityEditor.Progress;



public class TileManager : MonoBehaviour
{

    public class Struct
    {
        public Vector3Int position;
       public float f;
        public string name;
        public int count;

        public Struct(Vector3Int position, float f, string name)
        {
            this.position = position;
            this.f = f;
            this.name = name;
            count = 0;
        }

    }
    [SerializeField] public Tilemap interactive;
    [SerializeField] private Tile hiddenTile;
    [SerializeField] private Tile InteractedTile;
    //[SerializeField] public Tilemap interactive1;
    //[SerializeField] public Tilemap interactive2;
    //[SerializeField] public Tilemap interactive3;
    //private PolygonCollider2D polCollider;
    //private BoxCollider2D boxCollider;
    //[SerializeField] private Tile Chicken1;
    //[SerializeField] private Tile Chicken2;
    //[SerializeField] private Tile Chicken3;
    //[SerializeField] private Tile Chicken4;
    //[SerializeField] private Tile Chicken5;
    //[SerializeField] private Tile Chicken6;
    //[SerializeField] private Tile Chicken7;
    //[SerializeField] private Tile Chicken8;
    //[SerializeField] private Tile Chicken9;
    //[SerializeField] private Tile Chicken10;
    //[SerializeField] private Tile ChickenGate;
    public Dictionary<Vector3Int, Struct> Seeded { get; private set ; } = new Dictionary<Vector3Int, Struct>();
    void Start()
    {

        //polCollider = interactive1.GetComponent<PolygonCollider2D>();
        //boxCollider = interactive3.GetComponent<BoxCollider2D>();
        //polCollider.enabled = false;
        //boxCollider.enabled = false;
        foreach (var position in interactive.cellBounds.allPositionsWithin)
        {
            TileBase tile = interactive.GetTile(position);
            if (tile != null && tile.name == "Interactable")
            {
                interactive.SetTile(position, hiddenTile);
            }

        }

        //foreach (var position in interactive1.cellBounds.allPositionsWithin)
        //{
        //    TileBase tile = interactive1.GetTile(position);
        //    if (tile != null && tile.name == "Interactable")
        //    {
        //        interactive1.SetTile(position, hiddenTile);
        //    }

        //}
        //interactive2.GetComponent<TilemapRenderer>().sortingOrder = 2;
        //foreach (var position in interactive2.cellBounds.allPositionsWithin)
        //{
        //    TileBase tile = interactive2.GetTile(position);
        //    if (tile != null && tile.name == "Interactable")
        //    {
        //        interactive2.SetTile(position, hiddenTile);
        //    }

        //}

        //foreach (var position in interactive3.cellBounds.allPositionsWithin)
        //{
        //    TileBase tile = interactive3.GetTile(position);
        //    if (tile != null && tile.name == "Interactable")
        //    {
        //        interactive3.SetTile(position, hiddenTile);
        //    }

        //}
    }

    private void Update()
    {


        if (Seeded.Count != 0)
        {


            //Debug.Log("Masuk");

            foreach (var t in Seeded)
            {
                int timeElapsed = (int)GameManager.Instance.dayTimeController.Hours - (int)t.Value.f;

                if (timeElapsed < 0)
                {
                    timeElapsed += 24;
                }

                if (timeElapsed >= 6)
                {
                    if (t.Value.count < 7)
                    {
                  
                        t.Value.f = (t.Value.f + 6) % 24;
                        t.Value.count++;

                     
                        interactive.SetTile(
                            t.Value.position,
                            GameManager.Instance.cropManager.CropListState[t.Value.name][t.Value.count]
                        );
                    }
                }
            }


        }

        //if (GameManager.Instance.player.transform.position.y > (interactive2.transform.position.y + 6))
        //{
        //    interactive2.GetComponent<TilemapRenderer>().sortingOrder = 4;
        //}
        //else
        //{
        //    interactive2.GetComponent<TilemapRenderer>().sortingOrder = 2;
        //}


        //if (GameManager.Instance.player.transform.position.y > (interactive3.transform.position.y + 6))
        //{
     
        //    interactive3.GetComponent<TilemapRenderer>().sortingOrder = 4;
        //}
        //else
        //{
        //    interactive3.GetComponent<TilemapRenderer>().sortingOrder = 2;
        //}




    }

    void ChangeTilesBetween(Vector3Int start, Vector3Int end, Tile tile, Tilemap tiles)
    {
        // Loop through the range of tiles between A and B
        for (int x = Mathf.Min(start.x, end.x); x <= Mathf.Max(start.x, end.x); x++)
        {
            for (int y = Mathf.Min(start.y, end.y); y <= Mathf.Max(start.y, end.y); y++)
            {
                // Set the tile at the current position
                Vector3Int currentPosition = new Vector3Int(x, y, start.z);
                tiles.SetTile(currentPosition, tile);
            }
        }

        Debug.Log("Tiles changed from A to B!");
    }

    //public void ChickenPenBought()
    //{
    //    Vector3Int A = new Vector3Int(-14, 6, 0);
    //    Vector3Int B = new Vector3Int(-18, 6, 0);
    //    ChangeTilesBetween(A, B, Chicken1, interactive1);
    //     A = new Vector3Int(-19, 7, 0);
    //    B = new Vector3Int(-19, 14, 0);
    //    ChangeTilesBetween(A, B, Chicken2, interactive1);
    //     A = new Vector3Int(-11, 15, 0);
    //     B = new Vector3Int(-18, 15, 0);
    //    ChangeTilesBetween(A, B, Chicken3, interactive1);
    //     A = new Vector3Int(-10, 7, 0);
    //     B = new Vector3Int(-10, 14, 0);
    //    ChangeTilesBetween(A, B, Chicken4, interactive1);

    //    A = new Vector3Int(-10, 6, 0);
    //    interactive1.SetTile(A, Chicken5);
    //    A = new Vector3Int(-19, 6, 0);
    //    interactive1.SetTile(A, Chicken6);
    //    A = new Vector3Int(-19, 15, 0);
    //    interactive1.SetTile(A, Chicken7);
    //    A = new Vector3Int(-10, 15, 0);
    //    interactive1.SetTile(A, Chicken8);

    //    A = new Vector3Int(-10, 6, 0);
    //    interactive2.SetTile(A, Chicken5);

    //    A = new Vector3Int(-19, 6, 0);
    //    interactive1.SetTile(A, Chicken6);
    //    A = new Vector3Int(-14, 6, 0);
    //     B = new Vector3Int(-18, 6, 0);
    //    ChangeTilesBetween(A, B, Chicken1, interactive2);
    //    A = new Vector3Int(-12, 6, 0);
    //    interactive3.SetTile(A, ChickenGate);
    //    A = new Vector3Int(-11, 6, 0);
    //    interactive2.SetTile(A, Chicken9);
    //    A = new Vector3Int(-13, 6, 0);
    //    interactive2.SetTile(A, Chicken10);

    //    polCollider.enabled = true;
    //    boxCollider.enabled = true; 



    //}





    public bool isInteractable(Vector3Int position)
    {
        //Debug.Log($"BISA 4 {position}");
        TileBase tile = interactive.GetTile(position);
        //Debug.Log($"{tile}");
        if (tile != null)
        {
            //Debug.Log($"BISA2 {position}");
            if (tile.name == "Interactable_NotVis")
            {
                return true;
            }

        }
        return false;
    }

    public bool isPlowed(Vector3Int position)
    {
        TileBase tile = interactive.GetTile(position);
        if (tile != null)
        {
            Debug.Log($"BISA2 {position}");
            if (tile.name == "Summer_Plowed")
            {
                return true;
            }

        }
        return false;
    }

    public void Plow(Vector3Int position)
    {
        interactive.SetTile(position, InteractedTile);

        Debug.Log(position);


    }

    public bool Harvest(Vector3Int position)
    {
        Struct t;
        if (Seeded.ContainsKey(position))
        {
            t = Seeded[position];


            if (t.count >= 6)
            {
                Debug.Log("ACSADSA");
                t.count = 5;
                interactive.SetTile(t.position, GameManager.Instance.cropManager.CropListState[t.name][t.count]);
                Crops buffer = GameManager.Instance.cropManager.GetCropByName(t.name);
                Debug.Log(t.name);
                Debug.Log(buffer.cropdata.cropName);
                buffer.DropItem(position);
                return true;
            }
        }
        return false;
    }

    public void Seed(Vector3Int position, string name)
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAA");

           
            Struct buff = new Struct(position, GameManager.Instance.dayTimeController.Hours, name);
            Seeded[position] = buff;
            interactive.SetTile(position, GameManager.Instance.cropManager.GetFirstTile(name));
        Debug.Log(Seeded.Count);


    }
}
