using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ScriptableBattleTile : MonoBehaviour
{
    public Vector2Int GridMin;
    public Vector2Int GridMax;
    public bool TileTriggerable = false;
    public List<Vector2Int> InfectedTilesCoords;
    public Sprite RegularTile;
    public Sprite SelectedTile;
    public Sprite InfectedTile;
    public Sprite SelectedInfectedTile;
    public Sprite BrokenInfectedTile;
    public Sprite BrokenSelected;
    public GameObject BattleGrid;
    public int tilevalue;
    public int InfectedCount;

    private CursorTile ct;

    private void Start()
    {
        BattleGrid = GameObject.Find("BattleGrid");
        InfectedCount = InfectedTilesCoords.Count;
    }

    public void Update()
    {
        for (int i = 0; i < InfectedTilesCoords.Count; i++)
        {
            if (InfectedTilesCoords[i] == ct.CurrentSelection)
            {
                TileTriggerable = true;
            }
            else
            {
                TileTriggerable = false;
            }
        }
    }

    void ColorChanges(ITilemap tilemap, TileBase tilebase, ref TileData tiledata, Vector3Int position)
    {
        for (int i = GridMin.x; i == GridMax.x; i++)
        {
            for (int j = GridMin.y; j == GridMax.y; j++)
            {
                for (int k = 0; i < InfectedTilesCoords.Count; k++)
                {
                    if (tilemap.GetTile(new Vector3Int(InfectedTilesCoords[k].x, InfectedTilesCoords[k].y, 0)) == tilemap.GetTile(new Vector3Int(ct.CurrentSelection.x, ct.CurrentSelection.y, 0)))
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            tilebase.GetTileData(position, tilemap, ref tiledata);
                            tiledata.sprite = BrokenSelected;
                        }
                    }


                    if (tilemap.GetTile(new Vector3Int(i, j, 0)) == tilemap.GetTile(new Vector3Int(ct.CurrentSelection.x, ct.CurrentSelection.y, 0)))
                    {
                        tilebase.GetTileData(position, tilemap, ref tiledata);
                        tiledata.sprite = SelectedTile;
                    } 
                }
            }  
        }       
    }

    void Selection()
    {
        
    }
}
