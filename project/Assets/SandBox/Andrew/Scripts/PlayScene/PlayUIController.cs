using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayUIController : MonoBehaviour
{
    [SerializeField] GameObject m_pauseContainer, m_gameOverContainer, m_mainPlayUIContainer, m_ingameInstructions;
    [SerializeField] Image fader;


    private void Start()
    {
        m_ingameInstructions.SetActive(true);
        Cursor.visible = false;
        fader.CrossFadeAlpha(0, 1.5f, true);
        Invoke("DisableInstructions", 8);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && m_gameOverContainer.activeInHierarchy == false)
        {
            if (m_pauseContainer.activeInHierarchy)
            {
                UnpauseGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        //pause game
        Cursor.visible = true;
        ResetTimeScale(true);
        //Display menu
        m_pauseContainer.SetActive(true);
    }

    public void UnpauseGame()
    {
        Cursor.visible = false;
        ResetTimeScale(false);
        m_pauseContainer.SetActive(false);
    }

    public void GameOver()
    {
        //game over logic
        Cursor.visible = true;
        ResetTimeScale(true);
        //display game over
        m_gameOverContainer.SetActive(true);
        m_mainPlayUIContainer.SetActive(false);
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

    private void DisableInstructions()
    {
        m_ingameInstructions.SetActive(false);
    }
}
