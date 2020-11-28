using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Victory : MonoBehaviour
{
    public TextMeshProUGUI artCount;
    private void Awake()
    {
        winScreen();
    }
    public void winScreen()
    {
        string arts = GameObject.Find("Player").GetComponent<Status>().artifacts.ToString();
        artCount.SetText($"well done mr. bones, you rescued {arts} artifacts!");
    }
}
