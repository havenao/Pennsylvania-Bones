
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public bool playerWon = false;

    public void EndGame()
    {
        if (!gameHasEnded)
        {
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
