using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Grid<TGridObject>
{
    public event EventHandler<OnGridObjChangedEventArgs> OnGridObjChanged;
    public class OnGridObjChangedEventArgs : EventArgs{
        public int x;
        public int y;
    }

    int wight;
    int height;
    float cellSize;
    Vector3 originPosition;
    TGridObject[,] gridArray;

    public Grid(int wight, int height, float cellSize, Vector3 originPosition, Func<Grid<TGridObject>, int, int, TGridObject> createGridObj)
    {
        this.wight = wight;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        gridArray = new TGridObject[wight, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                gridArray[x,y] = createGridObj(this, x, y);
            }
        }
    }

    public float GetCellSize()
    {
        return cellSize;
    }

    public Vector3 GetWordPos(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    public void getXY(Vector3 wordPos, out int x, out int y)
    {
        x = Mathf.FloorToInt((wordPos + originPosition).x / cellSize);
        y = Mathf.FloorToInt((wordPos + originPosition).y / cellSize);
    }

    public void SetGridObj(int x, int y, TGridObject obj)
    {
        if(x >= 0 && y >= 0 && x < wight && y < height){
            gridArray[x,y] = obj;
            if(OnGridObjChanged != null) OnGridObjChanged(this, new OnGridObjChangedEventArgs{x = x, y = y});
        }
            
    }

    public void TriggerGridObjectChanged(int x , int y)
    {
        if(OnGridObjChanged != null) OnGridObjChanged(this, new OnGridObjChangedEventArgs{x = x, y = y});
    }

    public void SetGridObj(Vector3 wordPos, TGridObject obj)
    {
        int x, y;
        getXY(wordPos, out x, out y);
        SetGridObj(x, y, obj);
    }

    public TGridObject GetGridObj(int x, int y)
    {
        if(x >= 0 && y >= 0 && x < wight && y < height)
           return gridArray[x,y] ;

        return default(TGridObject);
    }

    public TGridObject GetGridObj(Vector3 wordPos)
    {
        int x, y;
        getXY(wordPos, out x, out y);
        return GetGridObj(x,y);
    }



}
