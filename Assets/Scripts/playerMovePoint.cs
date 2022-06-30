using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovePoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Level level = LevelManager.Instance.CurrentLevel;

        if (level.spawnFlame && collision.gameObject.CompareTag("Player"))
        {
            LevelManager.Instance.CurrentLevel.SpawnFlame();
        }
  
    }
}
