using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatformGenerator : MonoBehaviour
{
    [SerializeField] LevelGenerator levelGenerator;
    [Header("Disappearing Platforms")]
    [SerializeField] private GameObject disappearingPrefab;
    [SerializeField] private float disappearingMinY;
    [SerializeField] private float disappearingMaxY;
    [SerializeField] private int disappearingPlatformCount;
    [SerializeField] private float platformSpace;
    void Start()
    {
        float levelWidth = levelGenerator.GetLevelWidth();
        Vector3 spawnPosition = new Vector3();
        spawnPosition.y = spawnPosition.y + platformSpace;
        // Disappearing Platforms
        for (int i = 0; i < disappearingPlatformCount; i++)
        {
            spawnPosition.y += Random.Range(disappearingMinY, disappearingMaxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(disappearingPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
