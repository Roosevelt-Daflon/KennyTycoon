using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDispenser : PlacedObject
{
    [SerializeField] Transform Item;
    [SerializeField] float PassDaley;
    [SerializeField] float BeltSpeed;
    [SerializeField] float CurrentTime;
    [SerializeField] Transform itemPivo;

    public void Update() {
        
    }
}
