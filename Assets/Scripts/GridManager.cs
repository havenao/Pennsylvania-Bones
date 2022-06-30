using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private int xGridMax = 11;
    private int yGridMax = 8;

    private readonly float xOffset = 7.5f;
    private readonly float yOffset = 3.75f;

    [SerializeField] GridSpace[,] grid = new GridSpace[11, 8];
    public GridSpace[,] Grid => grid;

    public List<GridSpace> _availableSpaces;
    public List<GridSpace> AvailableSpaces => _availableSpaces;

    public List<GridSpace> AllSpaces;

    public void MakeGrid()
    {
        _availableSpaces = new List<GridSpace>();

        for (int y = 0; y < yGridMax; y++)
        {
            for (int x = 0; x < xGridMax; x++)
            {
                grid[x, y] = new GridSpace(new Vector3(x - xOffset, y - yOffset, 0));
                _availableSpaces.Add(grid[x, y]);
                AllSpaces.Add(grid[x, y]);
            }
        }
    }

    public void RemoveObject(GridObject gridObject)
    {
        ClearGridSpace(gridObject.Space);
    }

    private void ClearGridSpace(GridSpace gridSpace)
    {
        gridSpace.ClearObject();
        _availableSpaces.Add(gridSpace);
    }

    public void AddObjectToGridSpace(GridSpace gridSpace, GridObject gridObject)
    {
        gridSpace.AddObject(gridObject);
        _availableSpaces.Remove(gridSpace);
    }

    public GridSpace GetAvailableSpace(List<GridSpace> remainingSpaces = null)
    {
        if(remainingSpaces == null)
        {
            remainingSpaces = new List<GridSpace>(AvailableSpaces);
        }

        if (remainingSpaces.Count == 0)
        {
            // Todo: Lose The Game / Fire eats up items then lose the game?
            return null;
        }

        int randomIndex = Random.Range(0, remainingSpaces.Count);
        GridSpace space = remainingSpaces[randomIndex];

        // Too close to player
        if ((space.Position - Player.Instance.transform.position).magnitude <= 1)
        {
            remainingSpaces.Remove(space);
            space = GetAvailableSpace(remainingSpaces);
        }

        return space;
    }
}
