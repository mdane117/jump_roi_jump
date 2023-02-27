using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float distanceToCover;
    [SerializeField] private float lowerLimit;    
    [SerializeField] private float upperLimit;

    private float platformSpeed;
    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
        platformSpeed = Random.Range(lowerLimit, upperLimit);
    }

    private void Update()
    {
        MovePlatform();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
        
    }

    private void MovePlatform()
    {       
        Vector3 v = startingPosition;
        v.x += distanceToCover * Mathf.Sin(Time.time * platformSpeed);
        transform.position = v;
    }
}
