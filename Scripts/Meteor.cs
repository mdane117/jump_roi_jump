using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{   
    private void OnTriggerEnter(Collider other) 
    {
        Player player = other.GetComponent<Player>();
        if(player == null)
        {
            return;
        }

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
