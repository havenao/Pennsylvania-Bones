using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridObject : MonoBehaviour
{
    private GridSpace _space;
    public GridSpace Space => _space;

    public void SetSpace(GridSpace space)
    {
        _space = space;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == Player.Instance.gameObject) {

            PlayerPickup();
        }
    }

    protected abstract void PlayerPickup();

    protected void ClearGridObject()
    {
        LevelManager.Instance.CurrentLevel.Grid.RemoveObject(this);
        Destroy(this.gameObject);
    }
}
