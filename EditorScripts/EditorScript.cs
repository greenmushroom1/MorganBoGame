using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EditorScript : MonoBehaviour
{
    public Grid grid;

    [Header("SaveData Storage")]
    public GridMap gridMap;

    [Header("Color Panel")]
    public Color[] colors;
    int currentColor = 0;

    [Header("Height Panel")]
    float currentHeight = 0f;

    [Header("Generate Panel")]
    public Slider widthInput;
    public Slider heightInput;
    public InputField smoothnessInput;

    [Header("All Panels")]
    public GameObject[] panels;

    [Header("BrushSize")]
    public Text brushSizeText;
    public Slider brushSizeSlider;
    int brushSize = 1;

    public enum EditMode { Color, Height, Generate };
    EditMode currentMode = EditMode.Color;
    GridCell highlightedCell;

    private void Start()
    {
        brushSizeSlider.onValueChanged.AddListener(delegate { ChangeBrushSize(); });
        brushSizeText.text = "Brush Size: " + brushSizeSlider.value.ToString();
        smoothnessInput.GetComponent<SmoothnessSlider>().SetValue(grid.smoothing.ToString());
        FormatDisplay();
    }

    private void Update()
    {
        /*
        if (!Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(inputRay, out hit))
            {
                GridCell cell = grid.GetCellByPos(hit.point);
                if (highlightedCell != cell)
                {
                    if (highlightedCell != null)
                    {
                        highlightedCell.RemoveHighlight();
                        grid.UpdateSpecificCells(highlightedCell.transform.position, 1);
                    }
                    highlightedCell = grid.GetCellByPos(hit.point);
                    highlightedCell.Highlight();
                    grid.UpdateSpecificCells(hit.point, 1);
                }
            }
        }
        */
    }

    public void EditSquare(Vector3 point)
    {
        GridCell[] cells = grid.GetCellsByPosAndRange(point, brushSize);

        switch (currentMode)
        {
            case (EditMode.Color):
                ChangeColor(cells);
                break;
            case (EditMode.Height):
                ChangeHeight(cells);
                break;
        }
         grid.UpdateSpecificCells(point, brushSize);
       // grid.UpdateMeshes();
    }

    public void FormatDisplay()
    {
        foreach (GameObject  panel in panels) { panel.SetActive(false); }
        panels[(int)currentMode].SetActive(true);
    }

    public void ChangeColor(GridCell[] cells)
    {
        foreach (GridCell cell in cells) { cell.color = colors[currentColor]; }
    }

    public void ChangeHeight(GridCell[] cells)
    {
        foreach (GridCell cell in cells) { cell.height = currentHeight; }
    }

    public void ChangeEditMode(int mode)
    {
        currentMode = (EditMode)mode;
        FormatDisplay();
    }

    public void SetColor(int c)
    {
        currentColor = c;
    }

    public void SetHeight(float h)
    {
        currentHeight = h;
    }

    public void BuildMesh()
    {
      //  grid.ReBuildMesh((int)widthInput.value, (int)heightInput.value, float.Parse(smoothnessInput.text));
    }

    void ChangeBrushSize()
    {
        brushSizeText.text = "Brush Size: " + brushSizeSlider.value.ToString();
        brushSize = (int)brushSizeSlider.value;
    }

    public void SaveMap()
    {
        gridMap.colors = colors;
        gridMap.width = grid.width;
        gridMap.height = grid.height;
        gridMap.maxMeshSize = grid.maxMeshSize;

        GridMesh[,] meshes = grid.GetMeshesArray();
        int x = 0; int y = 0;
        for (int i = 0; i < meshes.GetLength(0); i++) { x += meshes[i, 0].cells.GetLength(0); }
        for (int i = 0; i < meshes.GetLength(1); i++) { y += meshes[0, i].cells.GetLength(1); }
        GridCell[,] cells = new GridCell[x, y];

        for (int ys = 0; ys<meshes.GetLength(1); ys++)
        {
            for (int xs = 0; xs<meshes.GetLength(0); xs++)
            {
                for (int yx = 0; yx<meshes[xs, ys].cells.GetLength(1); yx++)
                {
                    for (int xx = 0; xx<meshes[xs, ys].cells.GetLength(0); xx++)
                    {
                        cells[xx + xs * grid.maxMeshSize, yx + ys * grid.maxMeshSize] = meshes[xs, ys].cells[xx, yx];
                    }
                }
            }
        }
        gridMap.ProcessCells(cells);
    }
}
