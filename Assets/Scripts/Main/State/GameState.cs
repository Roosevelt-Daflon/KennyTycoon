using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class GameState : ScriptableObject
{
    public event Action<GameObject> onEditMode;
    public void EditMode(GameObject obj)
    {
        if(onEditMode == null) return;
        onEditMode(obj);
    }

    public event Action onGamePouse;
    public void GamePouse()
    {
        if(onGamePouse == null) return;
        onGamePouse();
    }
}
