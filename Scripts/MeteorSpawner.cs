using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] meteorPrefabs;
    private float minSecondsBetweenMeteors;
    private float maxSecondsBetweenMeteors;
    private float currentMinSecondsBetweenMeteors;
    private float currentMaxSecondsBetweenMeteors;

    private float forceRangeMin;
    private float forceRangeMax;
    private float currentForceRangeMin;
    private float currentForceRangeMax;
    [SerializeField] private GameObject player; 
    private Player playerScript;

    private Camera mainCamera;
    private float timer;

    [SerializeField] private float timerMultiplier; // originally 0.02
    [SerializeField] private float speedMultiplier; // originally 0.01
    
    // The following fields are for testing the values only. 
    [SerializeField] TMP_Text MaxHeight;
    [SerializeField] TMP_Text Timer;
    [SerializeField] TMP_Text MinSeconds;
    [SerializeField] TMP_Text MaxSeconds;
    [SerializeField] TMP_Text MinSpeed;
    [SerializeField] TMP_Text MaxSpeed;
    [SerializeField] MeteorFreeze meteorFreezeScript;
    bool currentlyFrozen;

    private void Start() // assign initial values for the meteor instantiator 
    {
        playerScript = player.GetComponent<Player>();
        mainCamera = Camera.main;
        timer = 30f;
        minSecondsBetweenMeteors = 15f; // originally 5
        maxSecondsBetweenMeteors = 25f; // originally 15
        forceRangeMin = 2f;
        forceRangeMax = 4f;
    }

    private void Update()
    {
        SpawnMeteorTimer();
        TimerLimiter();
        SpeedLimiter();
        MetricsDisplay();
        GetFrozenStatus();
    }

    private void GetFrozenStatus()
    {
        currentlyFrozen = meteorFreezeScript.isFrozen;
    }

    private void SpawnMeteorTimer() // Timer to spawn the meteor
    {
        if(!currentlyFrozen)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                SpawnMeteor();
                
                timer += Random.Range(currentMinSecondsBetweenMeteors, currentMaxSecondsBetweenMeteors);
            }
        }
    }

    private void TimerLimiter() // Used to decrease the time between meteors based on player height within the game
    {
        currentMinSecondsBetweenMeteors = (minSecondsBetweenMeteors - (playerScript.maxHeight * timerMultiplier)); 
        currentMaxSecondsBetweenMeteors = (maxSecondsBetweenMeteors - (playerScript.maxHeight * timerMultiplier * 2f));

        if (currentMinSecondsBetweenMeteors <=1)
        {
            currentMinSecondsBetweenMeteors = 1f;
        }

        if (currentMaxSecondsBetweenMeteors <=3)
        {
            currentMaxSecondsBetweenMeteors = 3f;
        }
    }

    private void SpeedLimiter() // used to increase the meteor speed based on the player height within the game
    {
        currentForceRangeMin = (forceRangeMin + (playerScript.maxHeight * speedMultiplier));
        currentForceRangeMax = (forceRangeMax + (playerScript.maxHeight * speedMultiplier));

        if (currentForceRangeMin >= 4f)
        {
            currentForceRangeMin = 4f;
        }

        if (currentForceRangeMax >= 6f)
        {
            currentForceRangeMax = 6f;
        }
    }

    private void MetricsDisplay() // For testing the values for TimeLimiter and SpeedLimiter functions only
    {
        MaxHeight.text = "MaxHeight: " + playerScript.maxHeight.ToString();
        Timer.text = "Timer: " + timer.ToString();
        MinSeconds.text = "MinSeconds: " + currentMinSecondsBetweenMeteors.ToString();
        MaxSeconds.text = "MaxSeconds: " + currentMaxSecondsBetweenMeteors.ToString();
        MinSpeed.text = "MinSpeed: " + currentForceRangeMin.ToString();
        MaxSpeed.text = "MaxSpeed: " + currentForceRangeMax.ToString();
    }
    private void SpawnMeteor() // Spawns the meteor at the top of the screen, with random speed and rotation
    {
        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;

        spawnPoint.x = Random.value;
        spawnPoint.y = 1;
        direction = new Vector2(Random.Range(-0.5f, 0.5f), -1f);

        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0;

        GameObject selectedMeteor = meteorPrefabs[Random.Range(0, meteorPrefabs.Length)];

        GameObject meteorInstance = Instantiate(selectedMeteor, worldSpawnPoint, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));

        Rigidbody2D rb = meteorInstance.GetComponent<Rigidbody2D>();

        rb.velocity = direction.normalized * Random.Range(currentForceRangeMin, currentForceRangeMax);
        //rb.velocity = new Vector2(0f, -Random.Range(forceRange.x, forceRange.y));
    }
}
