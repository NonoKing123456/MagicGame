using System;
using UnityEngine;

public class BattleGrid : MonoBehaviour
{
    public static BattleGrid Instance;
    [SerializeField] public Vector2[] gridEdges;
    [SerializeField, Min(1)] private int horizontalGridCount;
    [SerializeField, Min(1)] private int verticalGridCount;
    public int VerticalGridCount => verticalGridCount;
    public int HorizontalGridCount => horizontalGridCount;
    // All cell indices use [row, column]: top to bottom, then left to right.
    private Character[][] gridCells;

    private const double GeometryTolerance = 1e-6;
    private const float CellBoundaryTolerance = 1e-5f;
    private double gridOrientation;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        InitiateGrids();
    }

    private void InitiateGrids()
    {
        if (horizontalGridCount <= 0 || verticalGridCount <= 0)
        {
            Debug.LogError("BattleGrid row and column counts must be positive.", this);
            return;
        }

        string[] cornerNames = { "Top Left", "Top Right", "Bottom Left", "Bottom Right" };
        gridEdges = new Vector2[4];
        for (int i = 0; i < cornerNames.Length; i++)
        {
            Transform corner = transform.Find(cornerNames[i]);
            if (corner == null)
            {
                Debug.LogError($"BattleGrid is missing corner '{cornerNames[i]}'.", this);
                return;
            }
            gridEdges[i] = corner.position;
        }

        if (!ValidateGridShape())
        {
            Debug.LogError("BattleGrid corners must form a non-degenerate convex quadrilateral in Top Left, Top Right, Bottom Right, Bottom Left order.", this);
            return;
        }

        gridCells = new Character[verticalGridCount][];
        for (int row = 0; row < verticalGridCount; row++)
        {
            gridCells[row] = new Character[horizontalGridCount];
        }
    }

    private bool ValidateGridShape()
    {
        // Walk the perimeter; the serialized array stores the two top corners first.
        int[] perimeter = { 0, 1, 3, 2 };
        gridOrientation = 0;
        for (int i = 0; i < perimeter.Length; i++)
        {
            Vector2 a = gridEdges[perimeter[i]];
            Vector2 b = gridEdges[perimeter[(i + 1) % 4]];
            Vector2 c = gridEdges[perimeter[(i + 2) % 4]];
            if (!IsFinite(a) || !IsFinite(b) || !IsFinite(c)) return false;

            Vector2 edge = b - a;
            Vector2 nextEdge = c - b;
            double turn = Cross(edge, nextEdge);
            double scale = System.Math.Sqrt((double)edge.sqrMagnitude * nextEdge.sqrMagnitude);
            if (scale == 0 || System.Math.Abs(turn) <= GeometryTolerance * scale) return false;

            double orientation = System.Math.Sign(turn);
            if (gridOrientation == 0) gridOrientation = orientation;
            else if (gridOrientation != orientation) return false;
        }
        return true;
    }

    /// <summary>Returns [row, column] from world XY. Rows run top to bottom; columns left to right.</summary>
    public int[] FindCellByPosition(Vector2 position)
    {
        if (!TryFindCellByPosition(position, out Vector2Int cell))
        {
            //Debug.Log("Position is out of bounds or the grid is not initialized.");
            return new int[] { -1, -1 };
        }

        //Debug.Log($"Cell found at ({cell.x}, {cell.y}) with value {gridCells[cell.x][cell.y]}");
        return new int[] { cell.x, cell.y };
    }

    /// <summary>Returns (row, column) in cell.x and cell.y. Outer edges belong to the nearest cell.</summary>
    public bool TryFindCellByPosition(Vector2 position, out Vector2Int cell)
    {
        cell = new Vector2Int(-1, -1);
        if (gridCells == null || !IsFinite(position) || !ContainsPosition(position)) return false;

        // P(u,v) = topLeft + horizontal*u + vertical*v + twist*u*v.
        Vector2 horizontal = gridEdges[1] - gridEdges[0];
        Vector2 vertical = gridEdges[2] - gridEdges[0];
        Vector2 twist = (gridEdges[3] - gridEdges[2]) - horizontal;
        Vector2 offset = position - gridEdges[0];

        // A convex grid has exactly one row segment through an interior point.
        // Bisect the signed side of that segment instead of assuming vertical rows.
        double constant = Cross(horizontal, offset);
        double linear = Cross(twist, offset) - Cross(horizontal, vertical);
        double quadratic = -Cross(twist, vertical);
        double lower = 0;
        double upper = 1;
        for (int i = 0; i < 32; i++)
        {
            double middle = (lower + upper) * 0.5;
            double side = (constant + middle * (linear + middle * quadratic)) * gridOrientation;
            if (side > 0) lower = middle;
            else upper = middle;
        }

        double v = (lower + upper) * 0.5;
        double rowX = horizontal.x + twist.x * v;
        double rowY = horizontal.y + twist.y * v;
        double u = ((offset.x - vertical.x * v) * rowX + (offset.y - vertical.y * v) * rowY)
            / (rowX * rowX + rowY * rowY);
        cell = new Vector2Int(ToCellIndex((float)v, verticalGridCount), ToCellIndex((float)u, horizontalGridCount));
        return true;
    }

    private bool ContainsPosition(Vector2 position)
    {
        return IsInsideEdge(gridEdges[0], gridEdges[1], position)
            && IsInsideEdge(gridEdges[1], gridEdges[3], position)
            && IsInsideEdge(gridEdges[3], gridEdges[2], position)
            && IsInsideEdge(gridEdges[2], gridEdges[0], position);
    }

    private bool IsInsideEdge(Vector2 start, Vector2 end, Vector2 position)
    {
        Vector2 edge = end - start;
        return Cross(edge, position - start) * gridOrientation >= -GeometryTolerance * edge.sqrMagnitude;
    }

    private static int ToCellIndex(float coordinate, int count)
    {
        float scaled = Mathf.Clamp01(coordinate) * count;
        float boundary = Mathf.Round(scaled);
        // Exact internal boundaries belong to the column on the right / row below.
        if (Mathf.Abs(scaled - boundary) <= CellBoundaryTolerance) scaled = boundary;
        return Mathf.Clamp(Mathf.FloorToInt(scaled), 0, count - 1);
    }

    /// <summary>Returns the world XY center of a cell, using the same quadrilateral mapping.</summary>
    public Vector2 GetCellPosition(int row, int column)
    {
        if (gridCells == null) throw new System.InvalidOperationException("BattleGrid is not initialized.");
        if (row < 0 || row >= verticalGridCount) throw new System.ArgumentOutOfRangeException(nameof(row));
        if (column < 0 || column >= horizontalGridCount) throw new System.ArgumentOutOfRangeException(nameof(column));

        float u = (column + 0.5f) / horizontalGridCount;
        float v = (row + 0.5f) / verticalGridCount;
        Vector2 top = Vector2.Lerp(gridEdges[0], gridEdges[1], u);
        Vector2 bottom = Vector2.Lerp(gridEdges[2], gridEdges[3], u);
        return Vector2.Lerp(top, bottom, v);
    }

    private bool IsValidCell(int row, int column)
    {
        return row >= 0 && row < verticalGridCount && column >= 0 && column < horizontalGridCount;
    }

    private static double Cross(Vector2 a, Vector2 b)
    {
        return (double)a.x * b.y - (double)a.y * b.x;
    }

    private static bool IsFinite(Vector2 value)
    {
        return !float.IsNaN(value.x) && !float.IsInfinity(value.x)
            && !float.IsNaN(value.y) && !float.IsInfinity(value.y);
    }

    public void SetCell(int row, int column, Character character)
    {
        if (gridCells != null && IsValidCell(row, column))
        {
            gridCells[row][column] = SpawnCharacter(character, row, column);
        }
    }
    
    private Character SpawnCharacter(Character character, int row, int column)
    {
        Vector2 cellPosition = GetCellPosition(row, column);
        Vector3 birthPosition = new Vector3(cellPosition.x, cellPosition.y, 0);
        Character c = Instantiate(character.gameObject, birthPosition, Quaternion.identity, transform).GetComponent<Character>();
        AudioManager.Instance.PlayPlantedSFX();
        c.SetPlantedGrid(new int[] { row, column });
    
        return c;
    }
    public bool GetCellPlanted(int row, int column)
    {
        if (gridCells != null && IsValidCell(row, column) && gridCells[row][column] == null)
        {
            return false;
        }
        return true;
    }
    public void RemoveCharacter(Character character)
    {
        int[] plantedGrid = character.GetPlantedGrid();
        if (plantedGrid != null && IsValidCell(plantedGrid[0], plantedGrid[1]))
        {
            gridCells[plantedGrid[0]][plantedGrid[1]] = null;
        }
    }

    internal void RemoveCell(int row, int column)
    {
        if (gridCells != null && IsValidCell(row, column))
        {
            DestroyImmediate(gridCells[row][column].gameObject, true);
            gridCells[row][column] = null;
        }
    }
}
