using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameLevelScript : MonoBehaviour
{
    [SerializeField]GameObject Fire;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Wind"))
        {
            Fire.SetActive(false);
            Debug.Log("pufff");
        }

        if (other.CompareTag("Campfire"))
        {
            Fire.SetActive(true);
            Debug.Log("ich bin fire ");
        }
    }
}
