using UnityEngine;

public class PlayUIController : MonoBehaviour
{
    [SerializeField] GameObject m_pauseContainer;
    [SerializeField] GameObject m_gameOverContainer;

    public void PauseGame()
    {
        //pause game

        //Display menu
        m_pauseContainer.SetActive(true);
    }

    public void GameOver()
    {
        //game over logic

        //display game over
        m_gameOverContainer.SetActive(true);
    }
}