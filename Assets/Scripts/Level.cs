using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level : MonoBehaviour
{
    public int xGridMax;
    public int yGridMax;

    public bool spawnFlame = false;
    public bool nextLevel = false;

    public GameObject flame;
    public GameObject stairs;

    private GameObject prefabClone;

    public int[,] objectGrid = new int[11,8];
    private Vector3[,] spawnGrid = new Vector3[11,8];

    private readonly float xOffset = 7.5f;
    private readonly float yOffset = 3.75f;
    
  
    
    //Generate a 2D array of Locations
    void MakeGrids()
    {
        for (int y = 0; y < yGridMax; y++)
        {
            for (int x = 0; x < xGridMax; x++)
            {
                objectGrid[x, y] = 0;
                spawnGrid[x, y] = new Vector3(x - xOffset, y - yOffset, 0);
            }
        }
    }

    //Check if Grids are full so you can break loops
    bool IsGridFull()
    {
        int objectCounter = 0;
        for (int y = 0; y < yGridMax; y++)
        {
            for (int x = 0; x < xGridMax; x++)
            {
                if(objectGrid[x, y] == 1)
                {
                    objectCounter++;
                }
            }
        }
        //BAD CODE ALERT: NEEDS REFACTOR
        if (objectCounter == (xGridMax * yGridMax) - 2) //the -2 accounts for the spots that can't be targeted for spawning
        {
            return true;
        }
        else
            return false;
    }

    //spawn any object in the grid
    private void Spawn(GameObject prefab)
    {
        bool empty = false;
        int rX;
        int rY;

        if (!IsGridFull())
        {

            while (!empty)
            {

                System.Random r = new System.Random();
                rX = r.Next(0, xGridMax);
                rY = r.Next(0, yGridMax);

                if (objectGrid[rX, rY] == 0 && (spawnGrid[rX, rY] - GameObject.Find("Player").GetComponent<Transform>().transform.position).magnitude > 1)
                {
                    prefabClone = Instantiate(prefab, spawnGrid[rX, rY], Quaternion.identity) as GameObject;
                    objectGrid[rX, rY] = 1;
                    prefabClone.GetComponent<Obj>().x = rX;
                    prefabClone.GetComponent<Obj>().y = rY;
                    empty = true;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MakeGrids();
        Spawn(stairs);
    }

    // Update is called once per frame
    void Update()
    {
        //Spawn a flame every step (needs to spawn 1 flame per level every step)
        if(spawnFlame)
        {
            for (int i = 0; i < GameObject.Find("Player").GetComponent<Status>().level; i++)
            {
                Spawn(flame);
            }
            spawnFlame = false;
        }

        if(nextLevel)
        {
            Spawn(stairs);
            nextLevel = false;
        }

    }
}


