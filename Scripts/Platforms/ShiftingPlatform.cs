using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftingPlatform : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float distanceToCover;
    [SerializeField] private float platformSpeed;
    private Vector3 startingPosition;
    private bool movePlatform;
    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
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
                movePlatform = true;
            }
        }
        
    }

    private void MovePlatform()
    {
        if(movePlatform)
        {
            Vector3 v = startingPosition;
            v.x += distanceToCover * Mathf.Sin(Time.time * platformSpeed);
            transform.position = v;
            movePlatform = false;
            platformSpeed = -platformSpeed;
        }
    }
}
