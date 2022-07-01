using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAxe : Item
{
    public override void Use()
    {
        if (LevelManager.Instance.Floor > 1)
        {
            LevelManager.Instance.NewLevel();
        }
    }
}
