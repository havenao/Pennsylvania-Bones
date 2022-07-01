using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player Instance;
    private PlayerController _controller;
    public PlayerController Controller => _controller;

    private Animator _anim;
    public Animator Anim => _anim;

    public int health = 3;

    private int artifacts = 0;
    public int Artifacts => artifacts;

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

        _controller = GetComponent<PlayerController>();
        _anim = GetComponentInChildren<Animator>();
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
