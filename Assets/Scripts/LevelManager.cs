
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public Level levelPrefab;
    public GameObject groundLevel;
    [SerializeField] Transform tilemapParent; // (Grid)

    private int _floor = 10;
    public int Floor => _floor;
    private Level _currentLevel;
    public Level CurrentLevel => _currentLevel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        NewLevel(true);
    }


    public Action OnLevelChanged;

    public void NewLevel(bool isFirstLevel = false)
    {
        if (!isFirstLevel)
        {
            _floor -= 1;
            Destroy(CurrentLevel.gameObject);
        }
        _currentLevel = Instantiate(levelPrefab);
        _currentLevel.transform.parent = this.transform;
        OnLevelChanged?.Invoke();
    }

    public void GroundLevel()
    {
        groundLevel = Instantiate(groundLevel, tilemapParent);
    }
}

