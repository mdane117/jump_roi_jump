using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPlatformGenerator : MonoBehaviour
{
    [SerializeField] LevelGenerator levelGenerator;
    [Header("Broken Platforms")]
    [SerializeField] private GameObject brokenPrefab;
    [SerializeField] private float brokenMinY;
    [SerializeField] private float brokenMaxY;
    [SerializeField] private int brokenPlatformCount;
    [SerializeField] private float platformSpace;
    void Start()
    {
        float levelWidth = levelGenerator.GetLevelWidth();
        Vector3 spawnPosition = new Vector3();
        // Borken Platforms
        spawnPosition.y = spawnPosition.y + platformSpace;
        for (int i = 0; i < brokenPlatformCount; i++)
        {
            spawnPosition.y += Random.Range(brokenMinY, brokenMaxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(brokenPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
