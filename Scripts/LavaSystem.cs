using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSystem : MonoBehaviour
{
    [SerializeField] private Transform targetPosition;
    [SerializeField] private Rigidbody2D targetSpeed;
    //[SerializeField] public float smoothSpeed;
    //private Vector3 currentVelocity; // smoothing? might need work
    Rigidbody2D lavaRigidBody;
    [SerializeField] private float lavaSpeed;
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float lavaCatchupDistance;
    [SerializeField] private Player playerScript; 
    private bool playerIsAlive;
    
    private void Start()
    {
        lavaRigidBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        playerIsAlive = playerScript.isAlive;
        if(playerIsAlive == true)
        {
            LavaMovement();
        }
        else
        {
            Vector2 finishPos = new Vector2 (0f, transform.position.y);
            lavaRigidBody.gravityScale = 0f;
            lavaRigidBody.velocity = new Vector2 (0f, 0f);
        }     
    }

    private void LavaMovement()
    {
        if (targetPosition.position.y - transform.position.y > lavaCatchupDistance) // 10f
        {
            //Vector2 newPos = new Vector2 (0f, targetPosition.position.y - lavaCatchupDistance);
            //transform.position = newPos;
            lavaRigidBody.velocity = new Vector2 (0f, lavaSpeed * speedMultiplier * 2);
        }
        else
        {
            if (targetSpeed.velocity.y > lavaRigidBody.velocity.y)
            {
                lavaRigidBody.velocity = new Vector2 (0f, lavaSpeed * speedMultiplier);
            }
            else
            {
                lavaRigidBody.velocity = new Vector2 (0f, lavaSpeed);
            }
        }
    }
}
