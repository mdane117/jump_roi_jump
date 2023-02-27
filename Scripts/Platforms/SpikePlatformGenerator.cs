using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePlatformGenerator : MonoBehaviour
{
    [SerializeField] LevelGenerator levelGenerator;
    [Header("Spike Platforms")]
    [SerializeField] private GameObject spikePrefab;
    [SerializeField] private float spikeMinY;
    [SerializeField] private float spikeMaxY;
    [SerializeField] private int spikePlatformCount;
    [SerializeField] private float platformSpace;
    void Start()
    {
        float levelWidth = levelGenerator.GetLevelWidth();
        Vector3 spawnPosition = new Vector3();
        spawnPosition.y = spawnPosition.y + platformSpace;
        // Spike Platforms
        for (int i = 0; i < spikePlatformCount; i++)
        {
            spawnPosition.y += Random.Range(spikeMinY, spikeMaxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(spikePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
