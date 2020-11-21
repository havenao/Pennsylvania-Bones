using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovePoint : MonoBehaviour
{
    private Level level;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            level.spawnFlame = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.Find("Player").GetComponent<Level>();
    }
}
