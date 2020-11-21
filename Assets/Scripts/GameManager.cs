using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject level;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(level, new Vector3(-9f, 6f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
