using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid
{
    private int width;
    private int height;
    protected float cellSize;
    private int[,] gridArray;
    private TextMesh[,] debugTextArray;
    private Vector3 originPos;

    public Grid(int width, int height, float cellSize, Vector3 originPos)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPos = originPos;

        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                debugTextArray[x, y] = UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWordPos(x, y) + new Vector3(cellSize, cellSize) * .5f, 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWordPos(x, y), GetWordPos(x, y+1), Color.white, 100f);
                Debug.DrawLine(GetWordPos(x, y), GetWordPos(x+1, y), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWordPos(0, height), GetWordPos(width, height), Color.white, 100f);
        Debug.DrawLine(GetWordPos(width, 0), GetWordPos(width, height), Color.white, 100f);
    }

    private Vector3 GetWordPos(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPos;
    }

    private void GetXY(Vector3 wordPos, out int x, out int y)
    {
        x = Mathf.FloorToInt((wordPos - originPos).x / cellSize);
        y = Mathf.FloorToInt((wordPos - originPos).y / cellSize);
    }

    public void SetValue(int x, int y, int value)
    {
        if(x >= 0 && y >= 0 && x < width && y < height )
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    public void SetValue(Vector3 wordPos, int value)
    {
        int x, y;
        GetXY(wordPos,out x,out y);
        SetValue(x, y, value);
    }

    public int GetValue(int x, int y)
    {
        if(x >= 0 && y >= 0 && x < width && y < height )
        {
            return gridArray[x, y];
        }else
        {
            return 0;
        }
    }
    public int GetValue(Vector3 wordPos)
    {
        int x, y;
        GetXY(wordPos, out x, out y);
        return GetValue(x, y);
    }
}
