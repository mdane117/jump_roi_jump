using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPlatform : MonoBehaviour
{
    PlatformEffector2D platformEffector;
    EdgeCollider2D edgeCollider2d;
    Animator myAnimator;
    [SerializeField] private ParticleSystem crumblingEffect;

    private void Start()
    {
        platformEffector = GetComponent<PlatformEffector2D>();
        edgeCollider2d = GetComponent<EdgeCollider2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                platformEffector.enabled = false;
                edgeCollider2d.enabled = false;
                myAnimator.SetBool("isCrumbling", true);
                crumblingEffect.Play();
            }
        }
        
    }
}
