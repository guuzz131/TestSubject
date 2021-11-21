using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    [SerializeField] float speed;

    private Rigidbody rb;
    private float horizontalValue;
    private float verticalValue;
    Vector2 movement;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

        horizontalValue = Input.GetAxisRaw("Horizontal");
        verticalValue = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        movement = new Vector2(horizontalValue, verticalValue);
        movement = movement.normalized * speed;
        rb.velocity = new Vector3(movement.x, 0, movement.y);
    }
}
