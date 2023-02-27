using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteakPickup : MonoBehaviour
{
    [SerializeField] public float pointsForPickup;
    [SerializeField] GameObject floatingPoints;

    bool wasCollected = false;
    Vector3 pickupPosition;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<ScoreSystem>().IncreaseScore(pointsForPickup);
            pickupPosition = transform.position;
            Instantiate(floatingPoints, pickupPosition, Quaternion.identity);
            FindObjectOfType<AudioPlayer>().PlaySteakPickupSound();
            gameObject.SetActive(false);
            Destroy(gameObject);
        }    
    }
}
