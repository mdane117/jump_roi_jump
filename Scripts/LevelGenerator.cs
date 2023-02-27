using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Default Platforms")]
    public float m_SpawnDelay;
    [SerializeField]
    private float m_Timer;
    public Transform target;
    private List<GameObject> m_Platforms;

    public GameObject[] platformPrefab;
    public float levelWidth;
    public float minY; // original value is 0.5
    public float maxY; // original value is 2
    public int initialPlatforms;
    private Camera mainCamera;    

    void Start()
    {
        m_Platforms = new List<GameObject>();
        Vector3 spawnPosition = new Vector3();

        // Default Platforms
        for (int i = 0; i < initialPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            GameObject selectedPlatform = platformPrefab[Random.Range(0, platformPrefab.Length)];
            Instantiate(selectedPlatform, spawnPosition, Quaternion.identity);
        }

        

        // Attempting to spawn the platforms on the X axis using the World Points rather than a random in between values
        /*
        for (int i = 0; i < initialPlatforms; i++)
        {
            spawnPosition.y = Random.value;
            spawnPosition.x = Random.value;
            Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPosition);
            worldSpawnPoint.z = 0;
            Instantiate(platformPrefab, worldSpawnPoint, Quaternion.identity);
        }
        */
    }
    void Update()
    {
        m_Timer += Time.deltaTime;
        if (m_Timer >= m_SpawnDelay)
        {
            m_Timer = 0;
            Vector3 spawnPosition = new Vector3();
            spawnPosition.y += Random.Range(target.position.y + 1375.0f, target.position.y + 1376.5f);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            GameObject selectedPlatform = platformPrefab[Random.Range(0, platformPrefab.Length)];
            Instantiate(selectedPlatform, spawnPosition, Quaternion.identity);
        }
        
    } 

    public float GetLevelWidth()
    {
        return levelWidth;
    }
    void OnTriggerExit(Collider other) // this doesn't work but should be included http://oldforum.brackeys.com/thread/making-brackeys-doodle-jump-tutorial-infinite/
    {
        // Destroy everything that leaves the trigger
        if (m_Platforms.Contains(other.gameObject))
        {
            m_Platforms.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }

    /*
    public GameObject platformPrefab;
    public Transform target;
    public int numberOfPlatforms;
    public float levelWidth;
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }

        if(target.position.y > 20f)
        {
            for (int i = 0; i < numberOfPlatforms; i++)
            {
                spawnPosition.y += Random.Range(minY, maxY);
                spawnPosition.x = Random.Range(-levelWidth, levelWidth);
                Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            }
        }

        //InvokeRepeating("SpawnPlatforms", 0f, 1f);
    }
    */
}

