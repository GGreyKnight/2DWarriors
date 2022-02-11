using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 10f;

    public GameObject ladderBoard;
    public GameObject bestPlayer;

    public InputField playerName;

    bool clickOnce = false;

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            clickOnce = false;
            // GetComponent można używać gdy dwa skrypty są w tym samym obiekcie, inaczej potrzebna jest referencja
            //GetComponent<LadderBoard>().CheckForHighScore(UIManager.points);
            if (!GetComponent<LadderBoard>().CheckIfHighScore(UIManager.points))
            {
                bestPlayer.SetActive(false);
                ladderBoard.SetActive(true);
                Invoke("Restart", restartDelay);
            }
            ladderBoard.SetActive(true);
            //invoke
        }
    }

    public void InitialsEntered()
    {
        if(clickOnce == false)
        {
            GetComponent<LadderBoard>().CheckForHighScore(UIManager.points, playerName.text);
            clickOnce = true;
        }
        Invoke("Restart", restartDelay);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
