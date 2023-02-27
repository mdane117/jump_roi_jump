using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBubble : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] particleEffects;
    [SerializeField] private float secondsBetweenEffects;
    private float timer;
    
    void Start()
    {
        timer = 5f;
    }
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            SpawnAsteroid();

            timer += secondsBetweenEffects;
        }
    }

    private void SpawnAsteroid()
    {
        ParticleSystem selectedEffect = particleEffects[Random.Range(0, particleEffects.Length)];
        selectedEffect.Play();
    }
}
