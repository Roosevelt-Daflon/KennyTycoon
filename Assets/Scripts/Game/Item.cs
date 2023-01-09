using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool isMoving;
    [SerializeField] Vector3 nextPos;
    void Update()
    {
        if(isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, nextPos, 0.25f);
            if(transform.position == nextPos) isMoving = false;
        }
    }

    public void Move(Vector2 pos)
    {
        isMoving = true;
        nextPos = pos;
    }
}
