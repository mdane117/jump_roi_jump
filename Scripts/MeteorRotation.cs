using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorRotation : MonoBehaviour
{
    [SerializeField] private float minRotationSpeed;
    [SerializeField] private float maxRotationSpeed;
    private Vector3 rotation;
    private void Start()
    {
        rotation = new Vector3(0, 0, Random.Range(minRotationSpeed, maxRotationSpeed));
        
    }
    
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
