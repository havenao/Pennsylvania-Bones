using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject arrow;
    public GameObject heart;

    // Start is called before the first frame update
    void Start()
    {
        arrow = Instantiate<GameObject>(arrow, new Vector3(4.5f, 4.0f), Quaternion.identity);
        arrow.transform.parent = this.transform;
        DisplayHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayHealth()
    {
        GameObject healthBar = GameObject.Find("Health UI");
        float heartX = 4.3f;
        int health = GameObject.Find("Player").GetComponent<Status>().health;

        for (int i = 0; i < healthBar.transform.childCount; i++)
        {
            
            Destroy(healthBar.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < health; i++)
        {
            GameObject uiHeart = Instantiate<GameObject>(heart, new Vector3(heartX + i, -2.5f), Quaternion.identity);
            uiHeart.transform.parent = healthBar.transform;
        }
    }
}
