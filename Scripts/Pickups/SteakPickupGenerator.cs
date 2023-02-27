using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteakPickupGenerator : MonoBehaviour
{
    [SerializeField] LevelGenerator levelGenerator;
    [Header("Steak Pickup")]
    [SerializeField] private GameObject steakPickupPrefab;
    [SerializeField] private float pickupMinY;
    [SerializeField] private float pickupMaxY;
    [SerializeField] private int pickupCount;
    void Start()
    {
        float levelWidth = levelGenerator.GetLevelWidth();
        Vector3 spawnPosition = new Vector3();
        // Steak prefab
        for (int i = 0; i < pickupCount; i++)
        {
            spawnPosition.y += Random.Range(pickupMinY, pickupMaxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(steakPickupPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
