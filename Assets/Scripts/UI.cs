using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        arrow = Instantiate<GameObject>(arrow, new Vector3(4.5f, 4.0f), Quaternion.identity);
        arrow.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
