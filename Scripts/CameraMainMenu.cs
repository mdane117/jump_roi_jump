using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMainMenu : MonoBehaviour
{
    [SerializeField] public Transform target;

    void Update()
    {
        Vector3 newPos = new Vector3 (0f, target.position.y, -10f);
        transform.position = newPos;
    }
}
