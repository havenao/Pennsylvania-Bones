using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : GridObject
{
    protected override void PlayerPickup()
    {
        ResetGridSpace();
        Player.Instance.Anim.Play("Burn", -1, 0f);
        Player.Instance.TakeDamage();
    }
}
