using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Teste : MonoBehaviour
{
    private Grid grid;
    void Start()
    {
        grid = new Grid(4,2, 10f, new Vector3(20, 0));
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 1);
        }
    }

    
}
