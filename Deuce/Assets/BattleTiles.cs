using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BattleTiles : MonoBehaviour
{
    public bool TileTriggerable;
    public List<Vector2Int> InfectedTilesCoords;
    public GameObject BattleGrid;
    public int tilevalue;
    public int InfectedCount;
    public Vector3Int position;
    public Vector2Int CurrentPosition;
    public Tile Square;
    public Tile Selected;
    public Tile Infected;
    public Tile SelectedInfected;
    public Tile Broken;

    private Grid grid;

    private Tilemap tilemap;
    private ITilemap itilemap;
    private TileBase tilebase;
    private TileData tiledata;

    private Vector3Int UpPosition;
    private Vector3Int LeftPosition;
    private Vector3Int RightPosition;
    private Vector3Int DownPosition;

    private void Start()
    {
        BattleGrid = GameObject.Find("BattleGrid");
    }

    public void Update()
    {
        position = new Vector3Int(CurrentPosition.x, CurrentPosition.y, 0);
        UpPosition = new Vector3Int(CurrentPosition.x, CurrentPosition.y +1, 0);
        LeftPosition = new Vector3Int(CurrentPosition.x -1, CurrentPosition.y, 0);
        RightPosition = new Vector3Int(CurrentPosition.x +1, CurrentPosition.y, 0);
        DownPosition = new Vector3Int(CurrentPosition.x, CurrentPosition.y +1, 0);

        if (Input.GetKeyDown(KeyCode.W) && tilemap.HasTile(UpPosition) == true)
        {
            CurrentPosition.y = +1;
            tilemap.SetTile(position, Selected);
            tilemap.SetTile(DownPosition, Square);
            tilemap.RefreshAllTiles();
        }

        if (Input.GetKeyDown(KeyCode.A) && tilemap.HasTile(LeftPosition) == true)
        {
            CurrentPosition.x = -1;
            tilemap.SetTile(position, Selected);
            tilemap.SetTile(RightPosition, Square);
            tilemap.RefreshAllTiles();
        }

        if (Input.GetKeyDown(KeyCode.S) && tilemap.HasTile(DownPosition) == true)
        {
            CurrentPosition.y = -1;
            tilemap.SetTile(position, Selected);
            tilemap.SetTile(UpPosition, Square);
            tilemap.RefreshAllTiles();
        }

        if (Input.GetKeyDown(KeyCode.D) && tilemap.HasTile(RightPosition) == true)
        {
            CurrentPosition.x = +1;
            tilemap.SetTile(position, Selected);
            tilemap.SetTile(LeftPosition, Square);
            tilemap.RefreshAllTiles();
        }

        InfectedTileSprites();
                
    }

    public void CursorMoving()
    {
        
    }

    public void InfectedTileSprites()
    {
        //detects if the current tile is an infected tile
        for (int i = 0; i < InfectedTilesCoords.Count; i++)
        {
            if (InfectedTilesCoords[i] == CurrentPosition)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    tilemap.SetTile(position, Broken);
                    tilemap.RefreshTile(new Vector3Int(CurrentPosition.x, CurrentPosition.y, 0));
                }
            }
        }
    }
    
    

}
