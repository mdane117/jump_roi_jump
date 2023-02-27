using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcecreamPickup : MonoBehaviour
{
    bool wasCollected = false;
    [SerializeField] GameObject floatingText;
    Vector3 pickupPosition;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            pickupPosition = transform.position;
            Instantiate(floatingText, pickupPosition, Quaternion.identity);
            FindObjectOfType<AudioPlayer>().PlaySteakPickupSound();
            gameObject.SetActive(false);
            Destroy(gameObject);
        }    
    }
}
