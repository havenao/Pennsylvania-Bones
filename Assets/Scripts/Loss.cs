using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Loss : MonoBehaviour
{
    public TextMeshProUGUI loseText;
    private void Awake()
    {
        loseScreen();
    }
    public void loseScreen()
    {
        string artifactCount = GameObject.Find("SceneState").GetComponent<SceneState>().artifacts.ToString();
        loseText.SetText($"Aww shucks! Burned to a crisp with {artifactCount} artifacts!");
    }
}
