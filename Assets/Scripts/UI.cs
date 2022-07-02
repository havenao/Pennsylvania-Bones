using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public GameObject arrow;
    public GameObject heart;
    public Transform HealthContainer, TowerImage;
    [SerializeField] TextMeshProUGUI _artifactCounter;

    void Start()
    {
        MakeArrow();
        DisplayHealth(Player.Instance.Health);
    }

    private void DisplayHealth(int health)
    {        
        for (int i = 0; i < HealthContainer.transform.childCount; i++)
        {
            Destroy(HealthContainer.GetChild(i).gameObject);
        }
        for (int i = 0; i < health; i++)
        {
            GameObject uiHeart = Instantiate(heart, HealthContainer);
            uiHeart.transform.localPosition = new Vector3(i,  0, 0);            
        }
    }

    private void UpdateArtifactCount(int totalArtifacts)
    {
        _artifactCounter.SetText(totalArtifacts.ToString());
    }

    private void MakeArrow()
    {
        arrow = Instantiate(arrow, new Vector3(4.5f, 4.25f), Quaternion.identity);
        arrow.transform.parent = TowerImage;
    }

    private void MoveArrow()
    {
        if(LevelManager.Instance.Floor < 10)
        {
            arrow.transform.position -= new Vector3(0f, .5f);
        }
    }

    private void OnEnable()
    {
        Player.Instance.OnHealthChanged += DisplayHealth;
        Player.Instance.OnArtifactGained += UpdateArtifactCount;
        LevelManager.Instance.OnLevelChanged += MoveArrow;        
    }

    private void OnDisable()
    {
        Player.Instance.OnHealthChanged -= DisplayHealth;
        Player.Instance.OnArtifactGained -= UpdateArtifactCount;
        LevelManager.Instance.OnLevelChanged -= MoveArrow;
    }
}
