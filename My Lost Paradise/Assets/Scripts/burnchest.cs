using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burnchest : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity);
        {
            if (hit.collider.tag == "Chest3")
            {
                hit.transform.gameObject.GetComponent<Burning1>().ChestBurn();
                transform.gameObject.SetActive(false);
            }
        }
    }
}