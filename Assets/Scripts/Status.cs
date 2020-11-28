using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Status : MonoBehaviour
{
    public int health = 3;
    public int level = 1;
    public int score = 0;
    public int artifacts = 0;
    public TextMeshProUGUI artifactCount;

    public void TakeDamage()
    {
        health--;
        GameObject.Find("UI").GetComponent<UI>().DisplayHealth();
    }
    public void HealDamage()
    {
        health++;
        GameObject.Find("UI").GetComponent<UI>().DisplayHealth();
    }

    public void GetArtifact()
    {
        artifacts++;
        artifactCount = artifactCount.GetComponent<TextMeshProUGUI>();
        artifactCount.SetText(artifacts.ToString());
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
