using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public GameObject arrow;
    public GameObject heart;
    public Transform HealthContainer, TowerImage;
    public LevelManager LevelManager;
    [SerializeField] TextMeshProUGUI _artifactCounter;

    void Start()
    {
        MakeArrow();
        DisplayHealth();
    }

    private void DisplayHealth()
    {
        float heartX = 4.3f;
        int health = Player.Instance.health;
        

        for (int i = 0; i < HealthContainer.transform.childCount; i++)
        {
            Destroy(HealthContainer.GetChild(i).gameObject);
        }
        for (int i = 0; i < health; i++)
        {
            GameObject uiHeart = Instantiate(heart, new Vector3(heartX + i, -2.5f), Quaternion.identity);
            uiHeart.transform.parent = HealthContainer;
        }
    }

    private void UpdateArtifactCount(int totalArtifacts)
    {
        _artifactCounter.SetText(totalArtifacts.ToString());
    }

    private void MakeArrow()
    {
        arrow = Instantiate(arrow, new Vector3(4.5f, 4.0f), Quaternion.identity);
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
        LevelManager.OnLevelChanged += MoveArrow;
    }

    private void OnDisable()
    {
        Player.Instance.OnHealthChanged -= DisplayHealth;
        Player.Instance.OnArtifactGained -= UpdateArtifactCount;
        LevelManager.OnLevelChanged -= MoveArrow;
    }
}
