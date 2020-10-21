using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] ScriptableButtonEnum e_buttonPressed;
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
    }

    private void ExitButton()
    {
        Application.Quit();
    }

    private void OptionsButton()
    {
        //swap to the options screen
    }

    private void BackButton()
    {
        //return to the main menu
    }
}