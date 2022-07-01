using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level : MonoBehaviour
{
    public bool spawnFlame = false;

    [SerializeField] GridObject flame;
    [SerializeField] GridObject stairs;
    [SerializeField] GridObject heart;
    [SerializeField] GridObject fireAxe;
    [SerializeField] GridObject artifact;
    [SerializeField] GridObject coffee;
    [SerializeField] GridObject extinguisher;

    private GridManager grid;
    public GridManager Grid => grid;

    int currentFloor;
    // Start is called before the first frame update
    void Start()
    {
        currentFloor = LevelManager.Instance.Floor;
        grid = GetComponent<GridManager>();

        grid.MakeGrid();

        Spawn(heart);

        if (currentFloor > 1)
        {
            Spawn(stairs);
        }
        else
        {
            LevelManager.Instance.GroundLevel();
        }

        for (int i = 0; i < 11 - currentFloor; i++)
        {
            Spawn(artifact);
        }

        Spawn(GetItem());
        spawnFlame = true;
    }

    public void SpawnFlame()
    {
        for (int i = 11; i > currentFloor; i--)
        {
            Spawn(flame);
        }
    }

    // Spawn any object in the grid
    private void Spawn(GridObject prefab)
    {
        GridSpace space = grid.GetAvailableSpace();

        if (space == null) return;

        GridObject prefabClone = Instantiate(prefab, space.Position, Quaternion.identity);
        prefabClone.transform.parent = this.transform;

        grid.AddObjectToGridSpace(space, prefabClone);  
    }



    GridObject GetItem()
    {
        var Items = new List<GridObject>()
        {
            fireAxe
        };


        GridObject thisItem = Items[Random.Range(0, Items.Count)];
        return thisItem;
    }


}


