using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject level;
    public GameObject groundLevel;
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
        GameObject.Find("Player").GetComponent<Status>().level += 1;
        GameObject newLevel = Instantiate(level) as GameObject;
        newLevel.transform.parent = this.transform;
        GameObject.Find("arrow(Clone)").GetComponent<Transform>().transform.position -= new Vector3(0f, .5f);
        
    }

    public void GroundLevel()
    {
        
        groundLevel = Instantiate(groundLevel) as GameObject;
        groundLevel.transform.SetParent(GameObject.Find("Grid").transform);
    }
}

