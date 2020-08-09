using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject unitPrefab;
    public GridMapAdapter gridMapAdapter;

    List<GridCell> highlightedCells;
    UnitScript activeUnit;
    int team1units = 3;
    int team2units = 3;

    private void Start()
    {
        highlightedCells = new List<GridCell>();
        for (int i=0; i<team1units; i++)
        {
            UnitScript unit = Instantiate(unitPrefab, Vector3.zero, Quaternion.identity).GetComponent<UnitScript>();
            gridMapAdapter.PlaceUnitOnCell(unit, gridMapAdapter.gridMap.team1Spawns[i]);
            unit.manager = this;
            unit.team = 1;
            unit.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        for (int i = 0; i < team2units; i++)
        {
            UnitScript unit = Instantiate(unitPrefab, Vector3.zero, Quaternion.identity).GetComponent<UnitScript>();
            gridMapAdapter.PlaceUnitOnCell(unit, gridMapAdapter.gridMap.team2Spawns[i]);
            unit.manager = this;
            unit.team = 2;
            unit.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(inputRay, out hit))
            {
                switch (hit.collider.tag)
                {
                    case "Unit":
                        ClickUnit(hit.collider.GetComponent<UnitScript>());
                        break;
                    case "GridMesh":
                        gridMapAdapter.LeftClick(hit.point);
                        break;
                }
            }
        }
    }

    public void ClickUnit(UnitScript unit)
    {
        if (activeUnit != unit && activeUnit != null)
        {
            if (gridMapAdapter.GetCellByIndex(unit.cellIndex).IsHighlighted())
            {
                activeUnit.ProcessInteraction(unit);
            }
        }
        else {
            if (unit != null) { unit.LeftClick(); }
        }
        
    }

    public void MoveActiveUnit(IntVector2 index)
    {
        if (activeUnit == null) { return; }
        gridMapAdapter.PlaceUnitOnCell(activeUnit, index);
        activeUnit.status = UnitScript.UnitStatus.Idle;
        RemoveAllUnitRanges();
    }

    public void ShowUnitRange(UnitScript unit)
    {
        GridCell[] cells = gridMapAdapter.GetCellsByIndexAndRange(unit.cellIndex, unit.range);
        foreach (GridCell cell in cells)
        {
            cell.Highlight();
            highlightedCells.Add(cell);
        }
        gridMapAdapter.UpdateMeshes();
        activeUnit = unit;
    }

    public void RemoveAllUnitRanges()
    {
        foreach (GridCell cell in highlightedCells) { cell.RemoveHighlight(); }
        highlightedCells.Clear();
        gridMapAdapter.UpdateMeshes();
        if (activeUnit != null) { activeUnit.SetIdle(); }
        activeUnit = null;
    }
}
