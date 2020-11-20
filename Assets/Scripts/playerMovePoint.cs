using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovePoint : MonoBehaviour
{
    private ObjectSpawner myObjectSpawner;
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if(collision.gameObject.tag == "Player")
        {
            myObjectSpawner.spawnFlame = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        myObjectSpawner = GameObject.Find("Player").GetComponent<ObjectSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
