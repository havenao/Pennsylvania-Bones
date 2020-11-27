using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : Obj
{

    // Start is called before the first frame update
    void Start()
    {
        //Adjusts the sprite to be in the right place
        transform.position = new Vector3(transform.position.x, transform.position.y + .25f, transform.position.z);
    }

}
