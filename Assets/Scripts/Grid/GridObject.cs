using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    Grid<GridObject> grid;
    int x;
    int y;

    PlacedObject placedObject;

    public GridObject(Grid<GridObject> grid, int x, int y){
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void SetPlacedObject(PlacedObject placedObject)
    {
        this.placedObject = placedObject;
        grid.TriggerGridObjectChanged(x, y);
    }

    public PlacedObject GetPlacedObject()
    {
        return placedObject;
    }

    public void ClearPlacedObject()
    {
        placedObject = null;
        grid.TriggerGridObjectChanged(x, y);
    }

    public bool CanBuild()
    {
        return placedObject == null;
    }
}
