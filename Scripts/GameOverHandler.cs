using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private TMP_Text gameOverScoreText;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private GameObject inGameScoreText;
    [SerializeField] private GameObject gameControls;
    [SerializeField] private GameObject pauseText;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject playButton;

    private void Start()
    {
        inGameScoreText.gameObject.SetActive(true);
        gameOverDisplay.gameObject.SetActive(false);
    }
    public void EndGame()
    {
        inGameScoreText.gameObject.SetActive(false);
        int finalScore = scoreSystem.PauseScore();
        gameOverScoreText.text = $"Score: {finalScore}";
        gameOverDisplay.gameObject.SetActive(true);
        gameControls.gameObject.SetActive(false);
        pauseText.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
