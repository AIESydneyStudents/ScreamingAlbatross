using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject failMenu;
    [SerializeField] GameObject scoreMenu;
    [SerializeField] GameObject mainGameMenu;

    [SerializeField] GameObject endScoreMenu;
    private Text endScoreText;
    [SerializeField] GameObject finalScoreMenu;
    private Text finalScoreText;
    [SerializeField] GameObject timeTextMenu;
    private Text timeText;

    private float score;
    private Text scoreText;

    private void Start()
    {
        scoreText = scoreMenu.GetComponent<Text>();
        endScoreText = endScoreMenu.GetComponent<Text>();
        finalScoreText = finalScoreMenu.GetComponent<Text>();
        timeText = timeTextMenu.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (failMenu.activeInHierarchy)
        {
            mainGameMenu.SetActive(false);
            int scoreRounded = (int)score;
            endScoreText.text = "Score: " + scoreRounded.ToString();
            timeText.text = "Time: " + (int)Time.timeSinceLevelLoad;
            int finalScore = (int)(score + Time.timeSinceLevelLoad);
            finalScoreText.text = "Final Score: " + finalScore.ToString();

            
        }
        if (failMenu.activeInHierarchy == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape) == true)
            {
                if (pauseMenu.activeInHierarchy == true)
                    PauseMenuOff();
                else
                    PauseMenuOn();
            }
        }
        score += Time.deltaTime;
        int seconds = (int)score;

        scoreText.text = "Score :" + seconds.ToString();
    }
    public void PauseMenuOn()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
    }
    public void PauseMenuOff()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1.0f;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    
}
