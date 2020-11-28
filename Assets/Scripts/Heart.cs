using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Obj
{
    void Start()
    {
        //Adjusts the sprite to be in the right place
        transform.position = new Vector3(transform.position.x, transform.position.y + .25f, transform.position.z);
    }
}
