using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingMove : MonoBehaviour
{
    public float Speed = 3f;
    public float TurnSpeed = 180f;

    private Rigidbody rb;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        MovePlayer();
        TurnPlayer();
    }
    public void MovePlayer()
    {
       // Vector3 MoveVector = transform.TransformDirection(direction) * Speed;
       // rb.velocity = new Vector3(MoveVector.x,rb.velocity.y,MoveVector.z);
          Vector3 movement = transform.forward * Input.GetAxis("Vertical") * Speed * Time.deltaTime;
          rb.MovePosition(rb.position + movement); 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 5f,ForceMode.Impulse);
        }
    }
    public void TurnPlayer()
    {
            float turn = Input.GetAxis("Horizontal") * TurnSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f,turn,0f);
            rb.MoveRotation(rb.rotation * turnRotation);
    }
}

    // void FixedUpdate()
    // {
    //     float horizontalInput = Input.GetAxis("Horizontal");
    //     float verticalInput = Input.GetAxis("Vertical");

    //     Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;
        
    //     if (movement == Vector3.zero)
    //     {
    //         return;
    //     }

    //     Quaternion targetRotation = Quaternion.LookRotation(movement);

    //     Debug.Log(targetRotation.eulerAngles);

    //     targetRotation = Quaternion.RotateTowards(
    //         transform.rotation,
    //         targetRotation,
    //         360 * Time.fixedDeltaTime);

    //     rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    //     //rb.MoveRotation(targetRotation);
    //     //rb.transform.forward;
        
    // }
//     public CharacterController _controller;
//     public float _speed = 10;
//     public float _rotationSpeed = 180;
//     Rigidbody rb;
//     private Vector3 rotation;
//      private void Start() 
//      {
 
//         rb = GetComponent<Rigidbody>();
//         _controller = GetComponent<CharacterController>();
//     }
 
//     public void Update()
//     {
//         this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);
        
//         Vector3 direction = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
//         direction = this.transform.TransformDirection(direction);
//         _controller.Move(direction * _speed);
//         this.transform.Rotate(this.rotation);
//     }
