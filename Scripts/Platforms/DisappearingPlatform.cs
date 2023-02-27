using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    SpriteRenderer mySprite;
    PlatformEffector2D platformEffector;
    EdgeCollider2D edgeCollider2d;

    private bool isDisappearing;

    private float opacityLevel = 1f;

    [SerializeField] private float decayRate;

    private void Start()
    {
        platformEffector = GetComponent<PlatformEffector2D>();
        edgeCollider2d = GetComponent<EdgeCollider2D>();
        mySprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Disappear();
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                isDisappearing = true;
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
                platformEffector.enabled = false;
                edgeCollider2d.enabled = false;
                mySprite.color = new Color (1f, 1f, 1f, 1f);
            }
        }
        
    }

    private void Disappear()
    {
        if(isDisappearing)
        {
            opacityLevel -= (decayRate * Time.deltaTime);
            mySprite.color = new Color (1f, 1f, 1f, opacityLevel);
            if(opacityLevel <= 0)
            {
                mySprite.color = new Color (1f, 1f, 1f, 0f);
                isDisappearing = false;
            }
        }
        
    }
}
