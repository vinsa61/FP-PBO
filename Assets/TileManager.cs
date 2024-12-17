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
    [SerializeField] public Tilemap interactive1;
    [SerializeField] public Tilemap interactive2;
    [SerializeField] public Tilemap interactive3;
    [SerializeField] public Tilemap interactive4;
    [SerializeField] public Tilemap interactive5;
    [SerializeField] public Tilemap interactive6;


    [SerializeField] private Tile Fence1;
    [SerializeField] private Tile Fence2;
    [SerializeField] private Tile Fence3;
    [SerializeField] private Tile Fence4;
    [SerializeField] private Tile Fence5;
    [SerializeField] private Tile Fence6;
    [SerializeField] private Tile Fence7;
    [SerializeField] private Tile Fence8;
    [SerializeField] private Tile Gate;



    private PolygonCollider2D polCollider;
    private BoxCollider2D boxCollider;
    private PolygonCollider2D polCollider1;
    private BoxCollider2D boxCollider1;


    public Dictionary<Vector3Int, Struct> Seeded { get; private set ; } = new Dictionary<Vector3Int, Struct>();
    void Start()
    {

        polCollider = interactive1.GetComponent<PolygonCollider2D>();
        boxCollider = interactive3.GetComponent<BoxCollider2D>();
        polCollider1 = interactive4.GetComponent<PolygonCollider2D>();
        boxCollider1 = interactive6.GetComponent<BoxCollider2D>();

        polCollider.enabled = false;
        boxCollider.enabled = false;
        polCollider1.enabled = false;
        boxCollider1.enabled = false;

        ChangeAllToHidden(interactive);
        ChangeAllToHidden(interactive1);
        ChangeAllToHidden(interactive2);
        ChangeAllToHidden(interactive3);
        ChangeAllToHidden(interactive4);
        ChangeAllToHidden(interactive5);
        ChangeAllToHidden(interactive6);

    }

    private void Update()
    {
        int a;

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

        if (GameManager.Instance.player.transform.position.y > (interactive2.transform.position.y + 6))
        {
            interactive2.GetComponent<TilemapRenderer>().sortingOrder = 4;
        }
        else
        {
            interactive2.GetComponent<TilemapRenderer>().sortingOrder = 2;
        }


        if (GameManager.Instance.player.transform.position.y > (interactive3.transform.position.y + 6))
        {
     
            interactive3.GetComponent<TilemapRenderer>().sortingOrder = 4;
        }
        else
        {
            interactive3.GetComponent<TilemapRenderer>().sortingOrder = 2;
        }
        
        if (GameManager.Instance.player.transform.position.x >= 21)
        {
            a = 2;
        }
        else
        {
            a = 6;
        }

        if (GameManager.Instance.player.transform.position.y > (interactive5.transform.position.y + a) )
        {

            interactive5.GetComponent<TilemapRenderer>().sortingOrder = 4;
        }
        else
        {
            interactive5.GetComponent<TilemapRenderer>().sortingOrder = 2;
        }

        if (GameManager.Instance.player.transform.position.y > (interactive6.transform.position.y + a))
        {

            interactive6.GetComponent<TilemapRenderer>().sortingOrder = 4;
        }
        else
        {
            interactive6.GetComponent<TilemapRenderer>().sortingOrder = 2;
        }




    }



    public void ChickenPenBought()
    {

        ChangeAllTile(interactive1, Fence1);
        ChangeAllTile(interactive2, Fence2);


        var posA = new Vector3Int(-19, 15, 0);
        interactive2.SetTile(posA, Fence3);
        posA = new Vector3Int(-10, 15, 0);
        interactive2.SetTile(posA, Fence4);
        posA = new Vector3Int(-19, 6, 0);
        interactive2.SetTile(posA, Fence5);
        posA = new Vector3Int(-10, 6, 0);
        interactive2.SetTile(posA, Fence6);
        posA = new Vector3Int(-11, 6, 0);
        interactive2.SetTile(posA, Fence7);
        posA = new Vector3Int(-13, 6, 0);
        interactive2.SetTile(posA, Fence8);

        ChangeAllTile(interactive3, Gate);
 


        polCollider.enabled = true;
        boxCollider.enabled = true; 



    }

    public void CowPenBought()
    {

        ChangeAllTile(interactive4, Fence1);
        ChangeAllTile(interactive5, Fence2);

        var posA = new Vector3Int(10, 15, 0);
        interactive5.SetTile(posA, Fence3);
        posA = new Vector3Int(28, 15, 0);
        interactive5.SetTile(posA, Fence4);
        posA = new Vector3Int(21, 6, 0);
        interactive5.SetTile(posA, Fence4);
        posA = new Vector3Int(10, 6, 0);
        interactive5.SetTile(posA, Fence5);
        posA = new Vector3Int(21, 2, 0);
        interactive5.SetTile(posA, Fence5);
        posA = new Vector3Int(28, 2, 0);
        interactive5.SetTile(posA, Fence6);
        posA = new Vector3Int(25, 2, 0);
        interactive5.SetTile(posA, Fence7);
        posA = new Vector3Int(23, 2, 0);
        interactive5.SetTile(posA, Fence8);


        ChangeAllTile(interactive6, Gate);


        polCollider1.enabled = true;
        boxCollider1.enabled = true;

    }

    public void ChangeAllTile(Tilemap tiles, Tile tile)
    {
        foreach (var position in tiles.cellBounds.allPositionsWithin)
        {
            if (tiles.HasTile(position))
            {
                tiles.SetTile(position, tile);
            }
        }
    }

    public void ChangeAllToHidden(Tilemap tiles)
    {
        foreach (var position in tiles.cellBounds.allPositionsWithin)
        {
            TileBase tile = tiles.GetTile(position);
            if (tile != null && tile.name == "Interactable")
            {
                tiles.SetTile(position, hiddenTile);
            }

        }
    }


    public bool isInteractable(Vector3Int position)
    {
        Debug.Log($"BISA 4 {position}");
        TileBase tile = interactive.GetTile(position);
        Debug.Log($"{tile}");
        if (tile != null)
        {
            Debug.Log($"BISA2 {position}");
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
