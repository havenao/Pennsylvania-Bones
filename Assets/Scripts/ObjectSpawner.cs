using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectSpawner : MonoBehaviour
{
    public int xGridMax;
    public int yGridMax;


    public int playerX = 5;
    public int playerY = 0;

    public bool spawnFlame = false;

    public GameObject flame;
    GameObject flameClone;

    private int[,] objectGrid = new int[11,8];
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
        if (objectCounter == (xGridMax * yGridMax))
        {
            return true;
        }
        else
            return false;

        
    }

    // Start is called before the first frame update
    void Start()
    {
        MakeGrids();
        playerX = 5;
        playerY = 0;
}

    // Update is called once per frame
    void Update()
    {
        //Spawn a flame whenver any key is pressed (This needs to change to whenever Player moves)
        if(spawnFlame)
        {
            bool empty = false;
            int rX;
            int rY;
            
            if(!IsGridFull())
            {
                while (!empty)
                {
                    System.Random r = new System.Random();
                    rX = r.Next(0, xGridMax);
                    rY = r.Next(0, yGridMax);


                    if (objectGrid[rX, rY] == 0)
                    {
                        flameClone = Instantiate(flame, spawnGrid[rX, rY], Quaternion.identity) as GameObject;
                        objectGrid[rX, rY] = 1;

                        empty = true;
                    }
                }
            }
            spawnFlame = false;
        }
    }
}
