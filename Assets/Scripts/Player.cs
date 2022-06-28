using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public int health = 3;

    private int score = 0;
    private int artifacts = 0;
    public int Artifacts => artifacts;

    public TextMeshProUGUI artifactCount;

    public Action OnHealthChanged;
    public Action<int> OnArtifactGained;

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
    public void TakeDamage()
    {
        health--;
        OnHealthChanged?.Invoke();
    }
    public void HealDamage()
    {
        health++;
        OnHealthChanged?.Invoke();
    }

    public void GetArtifact()
    {
        artifacts++;
        OnArtifactGained?.Invoke(artifacts);
    }
}
