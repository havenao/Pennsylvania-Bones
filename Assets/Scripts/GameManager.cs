
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public bool playerWon = false;



    public void EndGame()
    {
        if (!gameHasEnded)
        {
            GameObject.Find("SceneState").GetComponent<SceneState>().UpdateState();
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
