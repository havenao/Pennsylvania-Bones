using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject level;
    // Start is called before the first frame update
    void Start()
    {
        NewLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewLevel()
    {
        GameObject newLevel = Instantiate(level) as GameObject;
        newLevel.transform.parent = this.transform;
    }
}

