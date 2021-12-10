using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    [SerializeField] GameObject camera;

    [SerializeField] FollowPlayer cameraFollowPlayer;

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
        
    }
    public void MoveInDirectionOfInput()
    {
        Vector3 dir = Vector3.zero;

        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        Vector3 camDirection = Camera.main.transform.rotation * dir;
        targetDirection = new Vector3(camDirection.x, 0, camDirection.z);

        if (dir != Vector3.zero && !cameraFollowPlayer.focussingCam)
        {
            transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(targetDirection),
            Time.deltaTime * 14
            );
        } else if (cameraFollowPlayer.focussingHeld)
        {
            Vector3 targetPostition = new Vector3(cameraFollowPlayer.enemy.transform.position.x,
                                        transform.position.y,
                                        cameraFollowPlayer.enemy.transform.position.z);
            transform.LookAt(targetPostition);
        }

        rb.velocity = targetDirection.normalized * speed;

    }
}
