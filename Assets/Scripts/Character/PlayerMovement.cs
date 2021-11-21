using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;
    private float horizontalValue;
    private float verticalValue;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
        rb2d.velocity = movement;
    }
}
