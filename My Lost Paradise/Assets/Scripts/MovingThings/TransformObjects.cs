using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TransformObjects : MonoBehaviour
{

    [SerializeField] GameObject UpDown;
    private Rigidbody rb;
    private Rigidbody rbT;

    public float TurnSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        TurnSpeed = (float)(rb.angularVelocity.y) * 0.1f;
        UpDown.transform.position += new Vector3(0, transform.position.y * TurnSpeed * 0.1f, 0);
        UpDown.transform.position = new Vector3(UpDown.transform.position.x, Mathf.Clamp(UpDown.transform.position.y, 28, 31), UpDown.transform.position.z);
        //Turn1.transform.Rotate(new Vector3(0, transform.position.y * TurnSpeed * 5f, 0));

    }
}