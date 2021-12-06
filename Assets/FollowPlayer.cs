using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float refocusSpeed;
    [SerializeField] private float refocusTime;

    bool refocus;

    void Update()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Vector3 playerRot = new Vector3(0, player.rotation.y, 0);
            //transform.DORotate(playerRot, refocusTime);
            Quaternion playerDir = Quaternion.LookRotation(player.GetComponent<PlayerMovement3D>().targetDirection);
            transform.DORotateQuaternion(playerDir, refocusTime);
        }

    }
    
}
