using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : GridObject
{
    protected override void PlayerPickup()
    {        
        LevelManager.Instance.NewLevel();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Adjusts the sprite to be in the right place
        transform.position = new Vector3(transform.position.x, transform.position.y + .25f, transform.position.z);
    }

}
