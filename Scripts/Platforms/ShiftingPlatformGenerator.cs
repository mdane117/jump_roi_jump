using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftingPlatformGenerator : MonoBehaviour
{
    [SerializeField] LevelGenerator levelGenerator;
    [Header("Shifting Platforms")]
    [SerializeField] private GameObject shiftingPrefab;
    [SerializeField] private float shiftingMinY;
    [SerializeField] private float shiftingMaxY;
    [SerializeField] private int shiftingPlatformCount;
    [SerializeField] private float platformSpace;
    void Start()
    {
        float levelWidth = levelGenerator.GetLevelWidth();
        Vector3 spawnPosition = new Vector3();
        spawnPosition.y = spawnPosition.y + platformSpace;
        // Shifting Platforms
        for (int i = 0; i < shiftingPlatformCount; i++)
        {
            spawnPosition.y += Random.Range(shiftingMinY, shiftingMaxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(shiftingPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
