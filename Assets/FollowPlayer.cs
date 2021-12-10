using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float refocusSpeed;
    [SerializeField] private float refocusTime;
    [SerializeField] private string searchTag;
    public bool focussingCam;

    public bool focussingHeld;

    public GameObject enemy;
    Vector3 focusTargetPos;
    Quaternion slowPlayerRot;
    void Start()
    {
        StartCoroutine(PerSecondUpdate());
    }

    IEnumerator PerSecondUpdate()
    {
        slowPlayerRot = player.rotation;
        yield return new WaitForSeconds(1f);
        if(player.rotation == slowPlayerRot && !focussingCam)
        {
            slowPlayerRot = player.rotation;
            transform.DORotateQuaternion(slowPlayerRot, 1);
        }
        StartCoroutine(PerSecondUpdate());
    }

    void Update()
    {
        if (!focussingHeld)
        {
            focusTargetPos = player.position;
        }
        else
        {
            focusTargetPos = (player.position + enemy.transform.position) / 2;
        }

        transform.position = new Vector3(focusTargetPos.x, focusTargetPos.y, focusTargetPos.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Vector3 playerRot = new Vector3(0, player.rotation.y, 0);
            //transform.DORotate(playerRot, refocusTime);
            StartCoroutine(HeldSpace());
            focussingCam = true;
            Quaternion playerDir = Quaternion.LookRotation(player.GetComponent<PlayerMovement3D>().targetDirection);
            transform.DORotateQuaternion(playerDir, refocusTime);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            focussingCam = false;
            focussingHeld = false;
        }
    }
    

    IEnumerator HeldSpace()
    {
        yield return new WaitForSeconds(0.1f);
        if (!focussingCam) yield break;
        focussingHeld = true;
        var found = GameObject.FindGameObjectsWithTag(searchTag);
        if (found.Length == 0)
        {
            enemy = null;
            yield break;
        }

        GameObject closest = null;
        var dist = Mathf.Infinity;
        foreach (var go in found)
        {

            var newDist = Vector3.Distance(go.transform.position, player.position);
            if (newDist < dist)
            {
                dist = newDist;
                closest = go;
            }
        }
        enemy = closest;

        
    }
}
