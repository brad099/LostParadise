using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;
    float _speed = 3f;

    void Start()    
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        Vector3 direction = Vector3.MoveTowards(transform.position, player.transform.position, _speed * Time.deltaTime);
        rb.MovePosition(direction);
        transform.LookAt(player.transform);
    }
}
