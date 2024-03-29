﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Victory : MonoBehaviour
{
    public TextMeshProUGUI winText;
    private void Awake()
    {
        winScreen();
    }
    public void winScreen()
    {
        string artifactCount = GameObject.Find("SceneState").GetComponent<SceneState>().artifacts.ToString();
        winText.SetText($"well done mr. bones, you rescued {artifactCount} artifacts!");
    }
}
