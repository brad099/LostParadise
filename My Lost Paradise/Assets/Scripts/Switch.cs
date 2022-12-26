using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] GameObject Platform;
    [SerializeField] bool isMoving;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isMoving = true;
            Debug.Log("Platform started moving");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isMoving = false;
            Debug.Log("Platform stopped moving");
        }
    }
}
