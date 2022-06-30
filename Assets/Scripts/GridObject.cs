using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    private GridSpace _space;
    public GridSpace Space => _space;

    public void SetSpace(GridSpace space)
    {
        _space = space;
    }
}
