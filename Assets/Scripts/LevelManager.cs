
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public Level levelPrefab;
    public GameObject groundLevel;

    public int Floor = 10;
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

    public void NewLevel(bool firstLevel)
    {
        if (!firstLevel)
        {
            Floor -= 1;
        }
        _currentLevel = Instantiate(levelPrefab);
        _currentLevel.transform.parent = this.transform;
        OnLevelChanged?.Invoke();
    }

    public void GroundLevel()
    {
        groundLevel = Instantiate(groundLevel);
        groundLevel.transform.SetParent(GameObject.Find("Grid").transform);
    }
}

