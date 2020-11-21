using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] ScriptableButtonEnum e_buttonPressed;
    [SerializeField] GameObject m_mainMenuObject, m_optionsMenuObject, m_confirmationPrompt, m_continueButton, m_creditsObject;
    [SerializeField] ScriptableVariableTransferObject m_vto;

    private void OnEnable()
    {
        /*if(//has saved game data)
        {
            m_continueButton.SetActive(true);
        }*/
        m_vto.Reset();
    }
    public void ButtonPressed()
    {
        switch(e_buttonPressed.m_Value)
        {
            case MenuButtons.Play:
                PlayButton();
                break;
            case MenuButtons.Exit:
                ExitButton();
                break;
            case MenuButtons.Options:
                OptionsButton();
                break;
            case MenuButtons.Back:
                BackButton();
                break;
            case MenuButtons.Continue:
                ContinueButton();
                break;
            case MenuButtons.MouseControls:
                MouseControlsButton();
                break;
            case MenuButtons.Theme:
                CreditsButton();
                break;
            case MenuButtons.None:
                break;
        }
    }
    private void CreditsButton()
    {
        m_creditsObject.SetActive(true);
        m_mainMenuObject.SetActive(false);
    }

    private void PlayButton()
    {
        //load the play scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void ExitButton()
    {
        //ends the application
        m_confirmationPrompt.SetActive(true);
    }

    private void OptionsButton()
    {
        //swap to the options screen
        m_optionsMenuObject.SetActive(true);
        m_mainMenuObject.SetActive(false);
    }

    private void BackButton()
    {
        //return to the main menu
        m_mainMenuObject.SetActive(true);
        m_optionsMenuObject.SetActive(false);
        m_creditsObject.SetActive(false);
    }
    private void ContinueButton()
    {
        //load game from saved data
    }
    private void MouseControlsButton()
    {

    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
