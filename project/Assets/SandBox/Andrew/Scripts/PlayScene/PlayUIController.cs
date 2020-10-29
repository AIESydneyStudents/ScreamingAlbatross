using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayUIController : MonoBehaviour
{
    [SerializeField] GameObject m_pauseContainer;
    [SerializeField] GameObject m_gameOverContainer;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    public void PauseGame()
    {
        //pause game
        ResetTimeScale(true);
        //Display menu
        m_pauseContainer.SetActive(true);
    }

    public void UnpauseGame()
    {
        ResetTimeScale(false);
        m_pauseContainer.SetActive(false);
    }

    public void GameOver()
    {
        //game over logic

        //display game over
        m_gameOverContainer.SetActive(true);
    }

    public void MainMenu()
    {
        ResetTimeScale(false);
        SceneManager.LoadScene(1);
    }

    public void PlayAgain()
    {
        ResetTimeScale(false);
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Options()
    {

    }

    private void ResetTimeScale(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}