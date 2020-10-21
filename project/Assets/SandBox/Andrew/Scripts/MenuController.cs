using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] ScriptableButtonEnum e_buttonPressed;
    [SerializeField] GameObject m_mainMenuObject;
    [SerializeField] GameObject m_optionsMenuObject;
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
            case MenuButtons.None:
                break;
        }
    }

    private void PlayButton()
    {
        //load the play scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void ExitButton()
    {
        //ends the application
        Application.Quit();
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
    }
}