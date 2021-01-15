using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript instance;


    [SerializeField]
    public GameObject pausePanel, gameOverPanel;

    [SerializeField]
    public Text gameOverScoreText, gameOverMaxScoreText, gameScore, gameOverText;

    [SerializeField] Image medal;
    [SerializeField] Sprite[] medals;

    [SerializeField] Button restartGameOverButton, pauseButton;
    void Awake()
    {
        makeInstance();
        Time.timeScale = 1f;
        pauseButton.gameObject.SetActive(true);
        gameScore.gameObject.SetActive(true); 
    }

    void makeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    public void setScore(int s)
    {
        gameScore.text = "" + s;
    }

    public void pause()
    {
        Time.timeScale = 0f;
        pauseButton.gameObject.SetActive(false);   
        pausePanel.SetActive(true);
    }

    public void resumePause()
    {
        Time.timeScale = 1f;
        pauseButton.gameObject.SetActive(true);   
        pausePanel.SetActive(false);
    }

    public void goToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void gameOver(int score, int maxScore)
    {
        Time.timeScale = 0f;
        pauseButton.gameObject.SetActive(false);
        gameScore.gameObject.SetActive(false); 
        gameOverPanel.SetActive(true);
        medal.gameObject.SetActive(false);
        gameOverText.text = "Game Over!";
        gameOverScoreText.text = "" + score;
        gameOverMaxScoreText.text = "" + maxScore;
        restartGameOverButton.onClick.RemoveAllListeners();
        restartGameOverButton.onClick.AddListener(() => restart());
    }

    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void completeLevel(int score, int maxScore, int spriteNumber)
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        gameScore.gameObject.SetActive(false);      
        gameOverText.text = "Level Complete!";
        medal.sprite = medals[spriteNumber];
        gameOverScoreText.text = "" + score;
        gameOverMaxScoreText.text = "" + maxScore;
        GameManager.instance.setLevelScore(SceneManager.GetActiveScene().name, spriteNumber+1);
        GameManager.instance.setSelectedLevel("Level" + (SceneManager.GetActiveScene().buildIndex + 1));
        unlockNextLevel();
        restartGameOverButton.onClick.RemoveAllListeners();
        restartGameOverButton.onClick.AddListener(() => nextLevel());
    }

    public void unlockNextLevel(){
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex + 1;
        string nextLevelName = "Level" + nextLevelIndex;
        GameManager.instance.unlockLevel(nextLevelName);
    }
    public void nextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
