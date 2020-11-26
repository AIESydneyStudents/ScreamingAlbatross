using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayUIController : MonoBehaviour
{
    [SerializeField] GameObject m_pauseContainer, m_gameOverContainer, m_mainPlayUIContainer, m_ingameInstructions, m_confirmationPrompt, m_options;
    [SerializeField] Image fader;


    private void Start()
    {
        m_ingameInstructions.SetActive(true);
        Invoke("FaderToClear", 1);
        Invoke("DisableInstructions", 8);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(m_ingameInstructions.activeInHierarchy)
            {
                DisableInstructions();
            }
            else if (!m_gameOverContainer.activeInHierarchy)
            {
                if(m_options.activeInHierarchy)
                {
                    Back();
                }
                else if (m_pauseContainer.activeInHierarchy)
                {
                    UnpauseGame();
                }
                else
                {
                    PauseGame();
                }
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

    public void QuitConfirmation()
    {
        m_confirmationPrompt.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Options()
    {
        m_pauseContainer.SetActive(false);
        m_options.SetActive(true);
    }

    public void Back()
    {
        m_pauseContainer.SetActive(true);
        m_options.SetActive(false);
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

    public void DisableInstructions()
    {
        m_ingameInstructions.SetActive(false);
        Cursor.visible = false;
    }
    
    void FaderToClear()
    {
        fader.CrossFadeAlpha(0, 3, true);
    }

}
