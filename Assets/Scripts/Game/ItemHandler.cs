using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] Transform item;
    [SerializeField] ItemHandler nextItemHandler;


    public void setItem(Transform item)
    {
        this.item = item;
        item.position = transform.position;
    }

    public void passItem()
    {
        if(item == null) return;

        nextItemHandler.setItem(item);
    }

    public void GetItemHandler()
    {
        
    }


}
