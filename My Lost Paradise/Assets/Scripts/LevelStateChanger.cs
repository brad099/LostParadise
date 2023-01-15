using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStateChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.transform.CompareTag("Player"))
        {
        CameraManager.Instance.OpenCamera("Level2");
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.transform.CompareTag("Player"))
        {
        CameraManager.Instance.OpenCamera("PlayerCamera");
        }
    }
}
