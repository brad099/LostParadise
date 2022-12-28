using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DoorOpener : MonoBehaviour
{
    [SerializeField]GameObject Door;
    [SerializeField]bool isOpened;


    private void OnTriggerEnter(Collider other) 
    {
            isOpened = true;
            Door.SetActive(true);
        
    }

    private void OnTriggerExit(Collider other) 
    {
            isOpened = false;
            Door.SetActive(false);
    }
}
