using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    [Header("Pause and Play Buttons")]
    [SerializeField] GameObject PauseButton;
    [SerializeField] GameObject PlayButton;
    [SerializeField] GameObject PauseText;

    private void Start()
    {
        Time.timeScale = 1;
        PauseButton.SetActive(true);
        PlayButton.SetActive(false);
        PauseText.SetActive(false);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseButton.SetActive(false);
        PlayButton.SetActive(true);
        PauseText.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseButton.SetActive(true);
        PlayButton.SetActive(false);
        PauseText.SetActive(false);
    }
}
