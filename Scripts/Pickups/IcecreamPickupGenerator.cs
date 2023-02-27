using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcecreamPickupGenerator : MonoBehaviour
{
    [SerializeField] LevelGenerator levelGenerator;
    [Header("Icecream Pickup")]
    [SerializeField] private GameObject icecreamPickupPrefab;
    [SerializeField] private float pickupMinY;
    [SerializeField] private float pickupMaxY;
    [SerializeField] private int pickupCount;
    [SerializeField] private float pickupSpace;
    void Start()
    {
        float levelWidth = levelGenerator.GetLevelWidth();
        Vector3 spawnPosition = new Vector3();
        spawnPosition.y = spawnPosition.y + pickupSpace;
        // Icecream prefab
        for (int i = 0; i < pickupCount; i++)
        {
            spawnPosition.y += Random.Range(pickupMinY, pickupMaxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(icecreamPickupPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
