using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu]
public class GridMap : ScriptableObject
{
    public int width;
    public int height;
    public int maxMeshSize;

    public Color[] colors;

    public MapCells[] mapCells;

    public IntVector2[] team1Spawns;
    public IntVector2[] team2Spawns;

    [System.Serializable]
    public class MapCells
    {
        public float[] height;
        public Color[] color;

        public MapCells(int length)
        {
            height = new float[length];
            color = new Color[length];
        }
    }

    public void ProcessCells(GridCell[,] cells)
    {
        mapCells = new MapCells[cells.GetLength(1)];

        for (int y=0; y<cells.GetLength(1); y++)
        {
            mapCells[y] = new MapCells(cells.GetLength(0));
            for (int x=0; x<cells.GetLength(0); x++)
            {
                mapCells[y].height[x] = cells[x, y].height;
                mapCells[y].color[x] = cells[x, y].color;
            }
        }
    }
}
