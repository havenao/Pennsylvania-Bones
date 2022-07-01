using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAxe : GridObject
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + .25f, transform.position.z);
    }

    protected override void PlayerPickup()
    {        
        ResetGridSpace();
        // Todo: Add FireAxe To Inventory              
    }

}
