using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : GridObject
{
    protected override void PlayerPickup()
    {
        if (Player.Instance.Health < 5)
        {
            Player.Instance.HealDamage();
            ClearGridObject();
        }
    }
}
