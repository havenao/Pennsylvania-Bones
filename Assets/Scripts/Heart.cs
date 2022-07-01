using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : GridObject
{
    protected override void PlayerPickup()
    {
        if (Player.Instance.health < 5)
        {
            Player.Instance.HealDamage();
            ResetGridSpace();
        }
    }

    void Start()
    {
        //Adjusts the sprite to be in the right place
        transform.position = new Vector3(transform.position.x, transform.position.y + .25f, transform.position.z);
    }
}
