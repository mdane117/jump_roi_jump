using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFreeze : MonoBehaviour
{
    [SerializeField] private float freezeDuration;

    public bool isFrozen;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Icecream")
        {
            StartCoroutine("FreezeMeteor");
        }
    }

    IEnumerator FreezeMeteor()
    {
        isFrozen = true;
        yield return new WaitForSeconds (freezeDuration);
        isFrozen = false;
    }
}
