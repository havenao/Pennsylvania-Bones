using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int health = 3;
    public int level = 1;
    public int artifacts = 0;

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

}
