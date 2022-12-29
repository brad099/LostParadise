using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DoorOpener : MonoBehaviour
{
    [SerializeField] GameObject Door;

    private void OnTriggerStay(Collider other)
    {
        Door.SetActive(false);

    }

    private void OnTriggerExit(Collider other)
    {
        Door.SetActive(true);
    }
}
