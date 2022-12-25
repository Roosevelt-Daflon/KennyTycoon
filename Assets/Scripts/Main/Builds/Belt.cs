using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class Belt : IBuildable
{
    public bool IsPlace;

    public override void Move()
    {
        if(IsPlace) return;
        int x, y;
        GetXY(UtilsClass.GetMouseWorldPosition(),out x,out y);
        transform.position = new Vector3(x, y);
        if(Input.GetMouseButton(0)) Place();
    }

    public override void Place()
    {
        //! Programar checagem para o place

        IsPlace = true;
    }

    public override void Rotation()
    {
        throw new System.NotImplementedException();
    }

    
    void Update()
    {
        Move();
    }
}
