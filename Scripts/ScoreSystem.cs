using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier;
    [SerializeField] private float pauseTime;
    public const string HighScoreKey = "HighScore";
    [SerializeField] private GameObject player; 
    [SerializeField] public Player playerScript;
    public float finalScore;
    private bool shouldCount = true;

    float heightScore;
    float pointsToAdd;
    float addPickupScore;
    private void Start() 
    {
        playerScript = player.GetComponent<Player>();
    }
    private void Update()
    {
        HeightScore();
        UpdateScoreText();
    }

    public void HeightScore()
    {
        if(!shouldCount)
        {
            return;
        }
        heightScore = (playerScript.maxHeight * scoreMultiplier);
    }

    public void IncreaseScore(float pointsToAdd)
    {
        addPickupScore += pointsToAdd;
    }


    private void UpdateScoreText()
    {
        finalScore = addPickupScore + heightScore;
        scoreText.text = Mathf.FloorToInt(finalScore).ToString();
    }

    private void PauseBeforeClearingScore()
    {
        scoreText.text = string.Empty;
    }

    public int PauseScore()
    {
        shouldCount = false;
        Invoke("PauseBeforeClearingScore", pauseTime);
        return Mathf.FloorToInt(finalScore);
    }

    private void OnDestroy() 
    {
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        if(finalScore > currentHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(finalScore));
        }    
    }
}
