using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class GridBuildingSystem : MonoBehaviour
{
    [SerializeField] List<PlacedObjectTypeSO> placedObjectTypeSOList;
    PlacedObjectTypeSO placedObjectTypeSO;
    public Grid<GridObject> grid;
    [SerializeField] PlacedObjectTypeSO.Dir dir = PlacedObjectTypeSO.Dir.Down;

    public static GridBuildingSystem Instance;
    private void Awake() {
        Instance = this;
        int gridWight = 50;
        int gridHeight = 50;
        float cellSize = 1;
        grid = new Grid<GridObject>(gridWight, gridHeight, cellSize, Vector3.zero, (Grid<GridObject> g, int x, int y) => new GridObject(g, x, y));
        placedObjectTypeSO = placedObjectTypeSOList[0];
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0))
        {
            grid.getXY(UtilsClass.GetMouseWorldPosition(), out int x, out int y);
            
            List<Vector2Int> gridPositionList = placedObjectTypeSO.GetGridPositionList(new Vector2Int(x, y), dir);
            
            bool CanBuild = true;
            foreach (Vector2Int gridPos in gridPositionList)
            {
                if(!grid.GetGridObj(gridPos.x, gridPos.y).CanBuild()){
                    CanBuild = false;
                    break;
                }
            }
            if(CanBuild)
            {
                Vector2Int rotationOffset = placedObjectTypeSO.GetRotationOffset(dir);
                Vector3 placeObjWorldPosition = grid.GetWordPos(x,y) +
                    new Vector3(rotationOffset.x, rotationOffset.y) * grid.GetCellSize();

                PlacedObject placedObject = PlacedObject.Create(placeObjWorldPosition, new Vector2Int(x, y), dir, placedObjectTypeSO);

                foreach (Vector2Int gridPos in gridPositionList)
                {
                    grid.GetGridObj(gridPos.x, gridPos.y).SetPlacedObject(placedObject);
                }
            }else{
                UtilsClass.CreateWorldTextPopup("Nao da para construir aqui", UtilsClass.GetMouseWorldPosition());
            }
        }

        if(Input.GetMouseButton(1))
        {
            GridObject gridObject = grid.GetGridObj(UtilsClass.GetMouseWorldPosition());
            PlacedObject placedObject = gridObject.GetPlacedObject();
            if(placedObject != null)
            {
                placedObject.DestroySelf();

                List<Vector2Int> gridPositionList = placedObject.GetGridPositionList();
            
                foreach (Vector2Int gridPos in gridPositionList)
                {
                    grid.GetGridObj(gridPos.x, gridPos.y).ClearPlacedObject();
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.R)){
            dir = PlacedObjectTypeSO.GetNextDir(dir);

        }
    }
}
