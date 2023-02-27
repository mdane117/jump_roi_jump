using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private GameObject customizeMenu;

    private void Start()
    {
        OnApplicationFocus(true);
        controlsMenu.gameObject.SetActive(false);
        customizeMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            return;
        }

        int highScore = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);
        highScoreText.text = $"High Score: {highScore}";
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadControls()
    {
        mainMenu.gameObject.SetActive(false);
        controlsMenu.gameObject.SetActive(true);
    }

    public void LoadMainMenu()
    {
        controlsMenu.gameObject.SetActive(false);
        customizeMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

    public void LoadCustomizeMenu()
    {
        mainMenu.gameObject.SetActive(false);
        customizeMenu.gameObject.SetActive(true);
    }
}
