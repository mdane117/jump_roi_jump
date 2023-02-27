using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformGenerator : MonoBehaviour
{
    [SerializeField] LevelGenerator levelGenerator;
    [Header("Moving Platforms")]
    [SerializeField] private GameObject movingPrefab;
    [SerializeField] private float movingMinY;
    [SerializeField] private float movingMaxY;
    [SerializeField] private int movingPlatformCount;
    [SerializeField] private float platformSpace;
    void Start()
    {
        float levelWidth = levelGenerator.GetLevelWidth();
        Vector3 spawnPosition = new Vector3();
        spawnPosition.y = spawnPosition.y + platformSpace;
        // Moving Platforms
        for (int i = 0; i < movingPlatformCount; i++)
        {
            spawnPosition.y += Random.Range(movingMinY, movingMaxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(movingPrefab, spawnPosition, Quaternion.identity);
        }
    }

}
