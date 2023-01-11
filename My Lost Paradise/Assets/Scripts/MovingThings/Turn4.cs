using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Turn4 : MonoBehaviour
{
    private Rigidbody rb;
    public float TurnSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        TurnSpeed = (float)(rb.angularVelocity.y) * 0.1f;
    }
}