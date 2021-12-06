using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    [SerializeField] GameObject camera;

    [SerializeField] float speed;

    private Rigidbody rb;
    private float horizontalValue;
    private float verticalValue;
    Vector3 movement;

    public Vector3 targetDirection;

    bool focus;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            focus = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            focus = false;
        }
    }

    private void FixedUpdate()
    {

        MoveInDirectionOfInput();

            /*
        horizontalValue = Input.GetAxis("Horizontal");
        verticalValue = Input.GetAxis("Vertical");
        //camera forward and right vectors:
        var forward = camera.transform.forward;
        var right = camera.transform.right;

        //project forward and right vectors on the horizontal plane (y = 0)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        //this is the direction in the world space we want to move:
        var desiredMoveDirection = forward * verticalValue + right * horizontalValue;

        //now we can apply the movement:
        transform.Translate(desiredMoveDirection * speed * Time.deltaTime);

        /*
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward);
        targetRotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            360 * 3 * Time.deltaTime
            );
        

        if (focus) return;
        rb.MoveRotation(targetRotation);*/
        
    }
    public void MoveInDirectionOfInput()
    {
        Vector3 dir = Vector3.zero;

        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        Vector3 camDirection = Camera.main.transform.rotation * dir; //This takes all 3 axes (good for something flying in 3d space)    
        targetDirection = new Vector3(camDirection.x, 0, camDirection.z); //This line removes the "space ship" 3D flying effect. We take the cam direction but remove the y axis value

        if (dir != Vector3.zero)
        { //turn the character to face the direction of travel when there is input
            transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(targetDirection),
            Time.deltaTime * 14
            );
        }

        rb.velocity = targetDirection.normalized * speed;     //normalized prevents char moving faster than it should with diagonal input

    }
}
