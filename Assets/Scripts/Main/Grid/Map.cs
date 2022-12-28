using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    Cell[,] grid;

    public int xLength;
    public int yLength;
    public float cellSize;  
    void Awake()
    {
        grid = new Cell[xLength, yLength];
        for (int x = 0; x < xLength; x++)
        {
            for (int y = 0; y < yLength; y++)
            {
                Cell cell = new Cell(x, y, cellSize);
                grid[x, y] = cell;
            }
        }


        int rows = grid.GetUpperBound(0) + 1;
        int columns = grid.Length / rows;

        //gameObject.transform.position = new Vector3
    }
}
