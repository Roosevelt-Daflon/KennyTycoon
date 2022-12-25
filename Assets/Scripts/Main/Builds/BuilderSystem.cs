using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class BuilderSystem : MonoBehaviour
{
    [SerializeField] GameState gameState;

    public void Build(GameObject Obj)
    {
        Instantiate(Obj, UtilsClass.GetMouseWorldPosition(), Quaternion.identity);
    }

    
}
