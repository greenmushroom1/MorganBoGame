using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMapAdapter : MonoBehaviour
{
    public GridMap gridMap;

    public GridCell cellPrefab;
    public GridMesh meshPrefab;
    public GridManager gridManager;

    GridMesh[,] gridMeshes;

    private void Awake()
    {
        int totalY = (int)Mathf.Ceil((float)gridMap.height / (float)gridMap.maxMeshSize);
        int totalX = (int)Mathf.Ceil((float)gridMap.width / (float)gridMap.maxMeshSize);
        gridMeshes = new GridMesh[totalX, totalY];
        for (int y = 0; y < totalY; y++)
        {
            for (int x = 0; x < totalX; x++)
            {
                gridMeshes[x, y] = Instantiate(meshPrefab);
            }
        }
        CreateCells();
    }

    private void Start()
    {
        foreach (GridMesh mesh in gridMeshes)
        {
            mesh.Triangulate();
        }
        ProcessMeshInteractions();
        foreach (GridMesh mesh in gridMeshes)
        {
            mesh.ApplyTriangulation();
        }
    }

    public void CreateCells()
    {
        for (int y = 0; y < gridMeshes.GetLength(1); y++)
        {
            for (int xs = 0; xs < gridMeshes.GetLength(0); xs++)
            {
                int meshX = (xs + 1) * gridMap.maxMeshSize <= gridMap.width ? gridMap.maxMeshSize : gridMap.width % gridMap.maxMeshSize;
                int meshY = (y + 1) * gridMap.maxMeshSize <= gridMap.height ? gridMap.maxMeshSize : gridMap.height % gridMap.maxMeshSize;
                gridMeshes[xs, y].cells = new GridCell[meshX, meshY];

                for (int z = 0; z < meshY; z++)
                {
                    for (int x = 0; x < meshX; x++)
                    {
                        CreateCell(x, z, xs, y, gridMeshes[xs, y].cells);
                    }
                }
            }
        }
    }

    void CreateCell(int x, int z, int xs, int y, GridCell[,] cells)
    {
        Noise noise = new Noise();
        Vector3 position;
        position.x = x * GridMetrics.squareSize + xs * gridMap.maxMeshSize * GridMetrics.squareSize;
        position.y = 0f;
        position.z = z * GridMetrics.squareSize + y * gridMap.maxMeshSize * GridMetrics.squareSize;

        GridCell cell = cells[x, z] = Instantiate<GridCell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        cell.color = gridMap.mapCells[gridMap.maxMeshSize * y + z].color[xs * gridMap.maxMeshSize + x];
        cell.height = gridMap.mapCells[gridMap.maxMeshSize * y + z].height[xs * gridMap.maxMeshSize + x];
    }

    public void LeftClick(Vector3 point)
    {
        IntVector2 index = GetIndexByPos(point);
        GridCell cell = GetCellByIndex(index);
        if (cell.IsHighlighted())
        {
            gridManager.MoveActiveUnit(index);
        }
    }

    void ProcessMeshInteractions()
    {
        GridCell[,] zeroCell = new GridCell[1, 1];
        CreateCell(0, 0, 0, 0, zeroCell);
        zeroCell[0, 0].height = -10; zeroCell[0, 0].color = Color.black;
        for (int z = 0; z < gridMeshes.GetLength(1); z++)
        {
            for (int x = 0; x < gridMeshes.GetLength(0); x++)
            {
                for (int xs = 0; xs < gridMeshes[x, z].cells.GetLength(0); xs++)
                {
                    if (z - 1 < 0)
                    {
                        zeroCell[0, 0].transform.position = new Vector3(gridMeshes[x, z].cells[xs, 0].transform.position.x, zeroCell[0, 0].height, gridMeshes[x, z].cells[xs, 0].transform.position.z - GridMetrics.squareSize);
                        gridMeshes[x, z].DrawVerticalCellInteraction(zeroCell[0, 0], gridMeshes[x, z].cells[xs, 0]);
                    }
                    if (z + 1 >= gridMeshes.GetLength(1))
                    {
                        zeroCell[0, 0].transform.position = new Vector3(gridMeshes[x, z].cells[xs, gridMeshes[x, z].cells.GetLength(1) - 1].transform.position.x, zeroCell[0, 0].height, gridMeshes[x, z].cells[xs, gridMeshes[x, z].cells.GetLength(1) - 1].transform.position.z + GridMetrics.squareSize);
                        gridMeshes[x, z].DrawVerticalCellInteraction(gridMeshes[x, z].cells[xs, gridMeshes[x, z].cells.GetLength(1) - 1], zeroCell[0, 0]);
                    }
                    else
                    {
                        gridMeshes[x, z].DrawVerticalCellInteraction(gridMeshes[x, z].cells[xs, gridMeshes[x, z].cells.GetLength(1) - 1], gridMeshes[x, z + 1].cells[xs, 0]);
                    }
                }
                for (int zs = 0; zs < gridMeshes[x, z].cells.GetLength(1); zs++)
                {
                    if (x - 1 < 0)
                    {
                        zeroCell[0, 0].transform.position = new Vector3(gridMeshes[x, z].cells[0, zs].transform.position.x - GridMetrics.squareSize, zeroCell[0, 0].height, gridMeshes[x, z].cells[0, zs].transform.position.z);
                        gridMeshes[x, z].DrawHorizontalCellInteraction(zeroCell[0, 0], gridMeshes[x, z].cells[0, zs]);
                    }
                    if (x + 1 >= gridMeshes.GetLength(0))
                    {
                        zeroCell[0, 0].transform.position = new Vector3(gridMeshes[x, z].cells[gridMeshes[x, z].cells.GetLength(0) - 1, zs].transform.position.x + GridMetrics.squareSize, zeroCell[0, 0].height, gridMeshes[x, z].cells[gridMeshes[x, z].cells.GetLength(0) - 1, zs].transform.position.z);
                        gridMeshes[x, z].DrawHorizontalCellInteraction(gridMeshes[x, z].cells[gridMeshes[x, z].cells.GetLength(0) - 1, zs], zeroCell[0, 0]);
                    }
                    else
                    {
                        gridMeshes[x, z].DrawHorizontalCellInteraction(gridMeshes[x, z].cells[gridMeshes[x, z].cells.GetLength(0) - 1, zs], gridMeshes[x + 1, z].cells[0, zs]);
                    }
                }
            }
        }
    }

    public void UpdateMeshes()
    {
        foreach (GridMesh mesh in gridMeshes) { mesh.Triangulate(); }
        ProcessMeshInteractions();
        foreach (GridMesh mesh in gridMeshes) { mesh.ApplyTriangulation(); }
    }

    public void PlaceUnitOnCell(UnitScript unit, IntVector2 index)
    {
        GridCell cell = GetCellByIndex(index);
        unit.transform.position = new Vector3(
            cell.transform.position.x, 
            cell.transform.position.y + GridMetrics.squareSize / 2f + cell.height, 
            cell.transform.position.z
            );
        unit.cellIndex = index;
    }

    public IntVector2 GetIndexByPos(Vector3 pos)
    {
        return new IntVector2(
                Mathf.FloorToInt((pos.x + GridMetrics.squareSize / 2) / GridMetrics.squareSize),
                Mathf.FloorToInt((pos.z + GridMetrics.squareSize / 2) / GridMetrics.squareSize)
            );
    }

    public GridCell GetCellByIndex(IntVector2 index)
    {
        if (index.x >= gridMap.width || index.y >= gridMap.height || index.x < 0 || index.y < 0) {
            Debug.Log("Invalid Index for cell retrieval");
            return null;
        }
        return gridMeshes[
                Mathf.FloorToInt((float)index.x / (float)gridMap.maxMeshSize),
                Mathf.FloorToInt((float)index.y / (float)gridMap.maxMeshSize)
            ].cells[
                index.x % gridMap.maxMeshSize,
                index.y % gridMap.maxMeshSize
            ];
    }

    public GridCell[] GetCellsByIndexAndRange(IntVector2 index, int range)
    {
        List<GridCell> returnCells = new List<GridCell>();
        IntVector2 meshIndex = new IntVector2(
            Mathf.FloorToInt((float)index.x / (float)gridMap.maxMeshSize),
            Mathf.FloorToInt((float)index.y / (float)gridMap.maxMeshSize)
            );
        IntVector2 cellIndex = new IntVector2(
                index.x % gridMap.maxMeshSize,
                index.y % gridMap.maxMeshSize
            );
        returnCells.Add(gridMeshes[meshIndex.x, meshIndex.y].cells[cellIndex.x, cellIndex.y]);

        int heldRange = range;
        int curX, curY;
        int maxMeshSize = gridMap.maxMeshSize;

        for (int y = 0; y < range ; y++)
        {
            curY = index.y - (y + 1);
            if (curY >= 0)
            {
                meshIndex.y = Mathf.FloorToInt(curY / maxMeshSize);
                cellIndex.y = Mathf.FloorToInt(curY % maxMeshSize);
                AddSpecificCell(returnCells, meshIndex, cellIndex);
            }
            curY = index.y + (y + 1);
            if (curY < gridMap.height)
            {
                meshIndex.y = Mathf.FloorToInt(curY / maxMeshSize);
                cellIndex.y = Mathf.FloorToInt(curY % maxMeshSize);
                AddSpecificCell(returnCells, meshIndex, cellIndex);
            }
        }

        for (int i=0; i<range; i++)
        {
            heldRange--;
            curX = index.x - (i + 1);
            if (curX >= 0)
            {
                meshIndex.x = Mathf.FloorToInt(curX / maxMeshSize);
                meshIndex.y = Mathf.FloorToInt((float)index.y / (float)gridMap.maxMeshSize);
                cellIndex.x = Mathf.FloorToInt(curX % maxMeshSize);
                cellIndex.y = index.y % gridMap.maxMeshSize;
                AddSpecificCell(returnCells, meshIndex, cellIndex);
                for (int y=0; y<heldRange; y++)
                {
                    curY = index.y - (y + 1);
                    if (curY >= 0)
                    {
                        meshIndex.y = Mathf.FloorToInt(curY / maxMeshSize);
                        cellIndex.y = Mathf.FloorToInt(curY % maxMeshSize);
                        AddSpecificCell(returnCells, meshIndex, cellIndex);
                    }
                    curY = index.y + (y + 1);
                    if (curY < gridMap.height)
                    {
                        meshIndex.y = Mathf.FloorToInt(curY / maxMeshSize);
                        cellIndex.y = Mathf.FloorToInt(curY % maxMeshSize);
                        AddSpecificCell(returnCells, meshIndex, cellIndex);
                    }
                }
            }
            curX = index.x + (i + 1);
            if (curX < gridMap.width)
            {
                meshIndex.x = Mathf.FloorToInt(curX / maxMeshSize);
                meshIndex.y = Mathf.FloorToInt((float)index.y / (float)gridMap.maxMeshSize);
                cellIndex.x = Mathf.FloorToInt(curX % maxMeshSize);
                cellIndex.y = index.y % gridMap.maxMeshSize;
                AddSpecificCell(returnCells, meshIndex, cellIndex);
                for (int y = 0; y < heldRange; y++)
                {
                    curY = index.y - (y + 1);
                    if (curY >= 0)
                    {
                        meshIndex.y = Mathf.FloorToInt(curY / maxMeshSize);
                        cellIndex.y = Mathf.FloorToInt(curY % maxMeshSize);
                        AddSpecificCell(returnCells, meshIndex, cellIndex);
                    }
                    curY = index.y + (y + 1);
                    if (curY < gridMap.height)
                    {
                        meshIndex.y = Mathf.FloorToInt(curY / maxMeshSize);
                        cellIndex.y = Mathf.FloorToInt(curY % maxMeshSize);
                        AddSpecificCell(returnCells, meshIndex, cellIndex);
                    }
                }
            }
        }
        return returnCells.ToArray();
    }

    void AddSpecificCell(List<GridCell> cells, IntVector2 mesh, IntVector2 cell) { cells.Add(gridMeshes[mesh.x, mesh.y].cells[cell.x, cell.y]); }
}
