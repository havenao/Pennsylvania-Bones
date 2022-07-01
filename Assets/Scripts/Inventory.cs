using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    List<Item> _items;
    int _selectIndex;

    private void AddItem(Item item)
    {

        item.transform.SetParent(this.transform);
        item.transform.localPosition = new Vector3(_items.Count,0,0);
        _items.Add(item);

        if(_items.Count == 1)
        {
            Reset();
        }
    }

    public void UseSelectedItem()
    {
        if (_items.Count == 0) return;

        Item item = _items[_selectIndex];
        item.Use();
        _items.Remove(item);
        Destroy(item.gameObject);

        if(_items.Count > 0)
        {
            Reset();
        }
    }

    public void SelectRight()
    {
        if(_selectIndex + 1 < _items.Count)
        {
            Select(_selectIndex + 1);
        }
    }

    public void SelectLeft()
    {
        if (_selectIndex - 1 >= 0)
        {
            Select(_selectIndex - 1);
        }
    }

    private void Select(int index)
    {
        _items[_selectIndex].transform.localScale = new Vector3(1, 1, 1);

        _selectIndex = index;
        _items[_selectIndex].transform.localScale = new Vector3(1.2f, 1.2f, 1);
    }

    private void Reset()
    {
        _selectIndex = 0;

        for (int i = 0; i < _items.Count; i++)
        {
            _items[i].transform.localPosition = new Vector3(i, 0, 0);
        }

        Select(0);
    }
    private void OnEnable()
    {
        Item.OnGetItem += AddItem;
    }

    private void OnDisable()
    {
        Item.OnGetItem -= AddItem;
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SelectRight();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SelectLeft();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            UseSelectedItem();
        }
    }
}
