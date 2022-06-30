using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GridSpace
{

    Vector3 _position;
    public Vector3 Position => _position;

    public GridObject _currentObject;
    public GridObject CurrentObject => _currentObject;

    public GridSpace(Vector3 position)
    {
        _position = position;
    }

    public void AddObject(GridObject obj)
    {
        _currentObject = obj;
    }

    public void ClearObject()
    {
        _currentObject = null;
    }
}
