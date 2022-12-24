using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Teste : MonoBehaviour
{
    private Grid grid;
    public int cellSize;
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            int x,y;
            GetXY(UtilsClass.GetMouseWorldPosition(),out x,out y);
            Debug.Log(x + "-" + y);
        }
    }

    private void GetXY(Vector3 wordPos, out int x, out int y)
    {
        x = Mathf.FloorToInt((wordPos).x / cellSize);
        y = Mathf.FloorToInt((wordPos).y / cellSize);
    }

    
}
