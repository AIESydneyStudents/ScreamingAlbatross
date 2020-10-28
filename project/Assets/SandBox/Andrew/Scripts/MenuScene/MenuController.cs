using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] ScriptableButtonEnum e_buttonPressed;
    [SerializeField] GameObject m_mainMenuObject;
    [SerializeField] GameObject m_optionsMenuObject;
    [SerializeField] GameObject m_confirmationPrompt;
    [SerializeField] Text m_themeText, m_mouseControlsText;
    [SerializeField] ScriptableVariableTransferObject m_vto;
    Themes m_currentTheme;

    private void OnEnable()
    {
        m_currentTheme = Themes.Indian;
        ThemeButton();
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
            case MenuButtons.Theme:
                ThemeButton();
                break;
            case MenuButtons.MouseControls:
                MouseControlsButton();
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
    }
    private void ContinueButton()
    {
        //load game from saved data
    }

    private void ThemeButton()
    {
        //change theme selected
        m_currentTheme++;
        if(m_currentTheme > Themes.Indian)
        {
            m_currentTheme = Themes.Random;
        }
        m_themeText.text = Enum.GetName(typeof(Themes), m_currentTheme);
    }
    private void MouseControlsButton()
    {
        m_vto.m_MouseControls = !m_vto.m_MouseControls;
        if(m_vto.m_MouseControls)
        {
            m_mouseControlsText.text = "Enabled";
        }else
        {
            m_mouseControlsText.text = "Disabled";
        }
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
