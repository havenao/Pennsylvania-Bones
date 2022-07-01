using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : GridObject
{
    protected override void PlayerPickup()
    {
        Player.Instance.GetArtifact();
        ClearGridObject();
    }
}
