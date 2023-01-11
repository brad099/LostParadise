using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Turn3 : MonoBehaviour
{

    [SerializeField] GameObject UpDown;
    [SerializeField] GameObject UpDown2;
    private Rigidbody rb;
    public float TurnSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        TurnSpeed = (float)(rb.angularVelocity.y) * 0.1f;

        UpDown.transform.position += new Vector3(0, transform.position.y * TurnSpeed * 0.1f, 0);
        UpDown.transform.position = new Vector3(UpDown.transform.position.x, Mathf.Clamp(UpDown.transform.position.y, 30, 33.33f), UpDown.transform.position.z);

        UpDown2.transform.position += new Vector3(0, transform.position.y * TurnSpeed * 0.1f, 0);
        UpDown2.transform.position = new Vector3(UpDown2.transform.position.x, Mathf.Clamp(UpDown2.transform.position.y, 32, 35.4f), UpDown2.transform.position.z);

    }
}