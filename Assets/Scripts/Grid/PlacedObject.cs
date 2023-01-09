using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedObject : MonoBehaviour
{

    public static PlacedObject Create(Vector3 wordPosition, Vector2Int origin, PlacedObjectTypeSO.Dir dir, PlacedObjectTypeSO placedObjectTypeSO)
    {
        Transform placedObjTransform = Instantiate(placedObjectTypeSO.prefab, wordPosition, Quaternion.Euler(0,0,placedObjectTypeSO.GetRotationAngle(dir)));
        PlacedObject placedObject = placedObjTransform.GetComponent<PlacedObject>();
        placedObject.placedObjectTypeSO = placedObjectTypeSO;
        placedObject.origin = origin;
        placedObject.dir = dir;

        return placedObject;
    }
    PlacedObjectTypeSO placedObjectTypeSO;
    protected Vector2Int origin;
    protected PlacedObjectTypeSO.Dir dir;

    public List<Vector2Int> GetGridPositionList()
    {
        return placedObjectTypeSO.GetGridPositionList(origin, dir);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
