using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buildable : MonoBehaviour
{
    [SerializeField]protected bool IsPlace;
    protected int cellSize = 1;
    public abstract void Place();
    public abstract void Rotation();
    public abstract void Move();

    public virtual void GetXY(Vector3 wordPos, out int x, out int y)
    {
        x = Mathf.FloorToInt((wordPos).x / cellSize);
        y = Mathf.FloorToInt((wordPos).y / cellSize);
    }

}
