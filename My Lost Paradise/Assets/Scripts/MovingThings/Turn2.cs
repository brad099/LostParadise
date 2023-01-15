using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Turn2 : MonoBehaviour
{

    [SerializeField] GameObject UpDown;
    private Rigidbody rb;
    public float downSpeed;

    public float TurnSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        TurnSpeed = (float)(rb.angularVelocity.y) * 0.2f;
        UpDown.transform.position += new Vector3(0, transform.position.y * TurnSpeed * 0.1f, 0);
        UpDown.transform.position -= new Vector3(0, transform.position.y * downSpeed * Time.deltaTime, 0);
        UpDown.transform.position = new Vector3(UpDown.transform.position.x, Mathf.Clamp(UpDown.transform.position.y, 34f, 41f), UpDown.transform.position.z);

        // float clampedR = Mathf.Clamp(Turn1.transform.rotation.y, 0f ,180f);
        //.transform.eulerAngles = new Vector3(Turn1.transform.eulerAngles.x,clampedR,Turn1.transform.eulerAngles.z);
        // float _rotation = Mathf.Clamp(Turn1.transform.rotation.y, 0, 180);
        // Turn1.transform.rotation = Quaternion.Euler(Turn1.transform.rotation.x, _rotation, Turn1.transform.rotation.z);
        //Turn1.transform.eulerAngles = new Vector3(Turn1.transform.eulerAngles.x, Mathf.Clamp(Turn1.transform.eulerAngles.y, 0, 180), Turn1.transform.eulerAngles.z);
        //.transform.eulerAngles.y = Mathf.Clamp(Turn1.transform.eulerAngles.y, 0, -180);
    }
}