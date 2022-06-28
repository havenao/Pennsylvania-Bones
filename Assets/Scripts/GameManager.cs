
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    bool gameHasEnded = false;
    public bool playerWon = false;
    public SceneState SceneState;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            SceneState.UpdateState();
            if (!playerWon)
            {
                SceneManager.LoadScene("Lose");
                gameHasEnded = true;
                
            }
            else if (playerWon)
            {
                SceneManager.LoadScene("Victory");
                gameHasEnded = true;
            }
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
