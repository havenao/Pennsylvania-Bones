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

    [SerializeField] int _health = 3;
    public int Health => _health;

    private int artifacts = 0;
    public int Artifacts => artifacts;

    public Action<int> OnHealthChanged;
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
        _health--;
        OnHealthChanged?.Invoke(_health);
    }
    public void HealDamage()
    {
        _health++;
        OnHealthChanged?.Invoke(_health);
    }

    public void GetArtifact()
    {
        artifacts++;
        OnArtifactGained?.Invoke(artifacts);
    }
}
