using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerM : MonoBehaviour
{
    [SerializeField]private float MovementSpeed;
    [SerializeField]private float RotationSpeed;

    void FixedUpdate()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(h, v);
        var targetVector = new Vector3(inputVector.x, 0, inputVector.y);
        var movementVector = MoveTowardTarget(targetVector);
        RotateTowardMovementVector(movementVector);
    }

    private void RotateTowardMovementVector(Vector3 movementVector)
    {
        if (movementVector.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed);
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = MovementSpeed * Time.deltaTime;
        targetVector = Quaternion.Euler(0, 0, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.transform.CompareTag("Chest"))
        {
            CameraManager.Instance.OpenCamera("ChestCamera");
        }
    }
}
