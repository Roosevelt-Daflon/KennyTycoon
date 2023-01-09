using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : PlacedObject
{
    public Item HandleItem;
    [SerializeField] PlacedObject NextMachine;
    [SerializeField] float PassDaley;
    [SerializeField] float BeltSpeed;
    [SerializeField] float CurrentTime;
    [SerializeField] Transform itemPivo;

    private void Update() {
        if(NextMachine == null)
        {
            Vector2Int nextPos = PlacedObjectTypeSO.GetDirForwardVector(dir);
            GridObject gridObject = GridBuildingSystem.Instance.grid.GetGridObj(new Vector3Int(origin.x +nextPos.x,origin.y+nextPos.y));
            if(gridObject.GetPlacedObject() != null)
                NextMachine = gridObject.GetPlacedObject();

        }else if(HandleItem != null)
        {
            if(HandleItem.isMoving) return;
            if( NextMachine.GetComponent<ConveyorBelt>().HandleItem != null) return;
            CurrentTime += Time.deltaTime * BeltSpeed;
            if(CurrentTime >= PassDaley)
            {
                CurrentTime = 0;
                NextMachine.GetComponent<ConveyorBelt>().SetItem(HandleItem);
                HandleItem = null;
            }
        }
    }

    private void OnDestroy() {
        Destroy(HandleItem);
    }

    public void SetItem(Item item)
    {
        //int x,y;
        //GridBuildingSystem.Instance.grid.getXY(transform.position,out x, out y);
        HandleItem = item;
        item.Move(itemPivo.position);
    }
    

}
