using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTile : MonoBehaviour
{
    private ScriptableBattleTile sbt;
    private GameObject cursorTile;
    public bool CanMoveLeft = true;
    public bool CanMoveRight = true;
    public bool CanMoveUp = true;
    public bool CanMoveDown = true;
    public Vector2Int CurrentSelection;
    public Vector2Int[] NoHover;

    private Vector3 TempPos;

    void Start()
    {
        CurrentSelection.Clamp(sbt.GridMin, sbt.GridMax);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && CanMoveLeft == true)
        {
            CurrentSelection.x = CurrentSelection.x - 1;
        }

        if (Input.GetKeyDown(KeyCode.D) && CanMoveRight == true)
        {
            CurrentSelection.x = CurrentSelection.x + 1;
        }

        if (Input.GetKeyDown(KeyCode.W) && CanMoveUp == true)
        {
            CurrentSelection.y = CurrentSelection.y + 1;
        }

        if (Input.GetKeyDown(KeyCode.S) && CanMoveDown == true)
        {
            CurrentSelection.y = CurrentSelection.y - 1;
        }

        for (int i = 0; i < NoHover.Length; i++)
        {
            if (CurrentSelection.x == NoHover[i].x - 1 || CurrentSelection.y == NoHover[i].y)
            {
                CanMoveRight = false;
            }
            if (CurrentSelection.x == NoHover[i].x + 1 || CurrentSelection.y == NoHover[i].y)
            {
                CanMoveLeft = false;
            }
            if (CurrentSelection.y == NoHover[i].y - 1 || CurrentSelection.x == NoHover[i].x)
            {
                CanMoveUp = false;
            }
            if (CurrentSelection.y == NoHover[i].y + 1 || CurrentSelection.x == NoHover[i].x)
            {
                CanMoveDown = false;
            }
        }

        transform.position = TempPos;

    }
}
