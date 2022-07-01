using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : GridObject
{
    protected override void PlayerPickup()
    {        
        LevelManager.Instance.NewLevel();
    }
}
