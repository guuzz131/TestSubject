using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WeaponMoveMouse : MonoBehaviour
{

    [SerializeField] Animator animator;

    /*
    [SerializeField] private float maxAngle;
    [SerializeField] private float weaponSpeed;
    [SerializeField] private float turnTimer;
    [SerializeField] private float turnSpeed;

    float _turnValue;

    float _smt;


    private Vector3 camPosition;
    private Vector3 mousePosition;
    private Vector3 mouseDistance;
    float distance;[
    float currentLerpTime;
    float turnPlayer;*/

    void Start()
    {
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.Play("WeaponSwingLeft");
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.Play("WeaponSwingRight");
        }


        /*
        camPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        camPosition = transform.InverseTransformPoint(camPosition);
        Plane plane = new Plane(Vector3.up, 0);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            mousePosition = ray.GetPoint(distance);
            mousePosition = transform.InverseTransformPoint(mousePosition);
        }
        mouseDistance = mousePosition - camPosition;
        mouseDistance = new Vector3(Mathf.Clamp(mouseDistance.x, -10, 10), 0, Mathf.Clamp(mouseDistance.z, -10, 10));
        _turnValue = mouseDistance.x * weaponSpeed;
        _turnValue = Mathf.Clamp(_turnValue, -maxAngle, maxAngle);


        //Debug.Log(mouseDistance);
        
        transform.localRotation = Quaternion.Euler(transform.rotation.x, _turnValue, transform.rotation.z);

        
        /*
        if (_turnValue >= maxAngle - 5)
        {
            Debug.Log("Rechts " + turnPlayer);
            turnPlayer += turnSpeed * Time.deltaTime ;

            currentLerpTime += Time.deltaTime;

            transform.parent.transform.rotation = Quaternion.Lerp(
                transform.parent.transform.rotation,
                Quaternion.Euler(transform.parent.transform.rotation.x, transform.parent.transform.rotation.y + turnPlayer, transform.parent.transform.rotation.z),
                currentLerpTime);


            //transform.parent.transform.rotation = Quaternion.Euler(transform.parent.transform.rotation.x, transform.parent.transform.rotation.y + turnPlayer, transform.parent.transform.rotation.z);
        }
        else if (_turnValue <= -maxAngle + 5)
        {
            Debug.Log("Links " + turnPlayer);
            turnPlayer += turnSpeed * Time.deltaTime;
            currentLerpTime += Time.deltaTime;
            transform.parent.transform.rotation = Quaternion.Lerp(
                transform.parent.transform.rotation,
                Quaternion.Euler(transform.parent.transform.rotation.x, transform.parent.transform.rotation.y - turnPlayer, transform.parent.transform.rotation.z),
                currentLerpTime);
        }
        else
        {
            currentLerpTime = 0;
            //turnPlayer = transform.parent.transform.rotation.y;
        }*/
    }
}
