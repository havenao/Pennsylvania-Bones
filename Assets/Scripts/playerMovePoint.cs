using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovePoint : MonoBehaviour
{
    private Level flameSpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            flameSpawner.spawnFlame = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        flameSpawner = GameObject.Find("Level(Clone)").GetComponent<Level>();
    }
}
