using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //for chase state
    [Header("Chase State")]
    [SerializeField] private float chaseSpeed;
    private List<Vector2> walkPath = new List<Vector2>();
    private GameObject player;
    Vector2 dir;

    //for idle state
    [Header("Idle State")]
    [SerializeField] private float idleSpeed;
    [SerializeField] private float maxIdleRange;
    [SerializeField] private float waitTime;
    Vector2 startPos;
    Vector2 newPos;
    Vector2 dirIdle;
    bool rest;

    //[Header("Attacking State")]
    

    void Start()
    {
        player = GetComponent<EnemyStates>().player;
        startPos = transform.position;
        StartCoroutine("GetIdleNewPos", waitTime);
        walkPath.Add(transform.position);
    }

    public void Idle()
    {
        
        if (Vector2.Distance((Vector2)transform.position, newPos) <= 1) //if close to newpos, find newpos
        {
            if (!rest)
            {
                StartCoroutine("GetIdleNewPos", waitTime);
                rest = true;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, newPos, idleSpeed * Time.deltaTime);//move enemy to new pos
        }
        
        dirIdle = newPos - (Vector2)transform.position;
        dirIdle.Normalize();
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dirIdle, .7f, LayerMask.GetMask("Wall"));//check if would hit wall
        if (!hit) 
            return;

        if (Vector2.Distance(startPos, transform.position) > 2f) //if far from spawn, get new spawn, otherwise it might get stuck
            startPos = transform.position;

        StartCoroutine("GetIdleNewPos", waitTime);
    }
    IEnumerator GetIdleNewPos(float time) //get a new idle pos
    {
        yield return new WaitForSeconds(time);
        newPos = new Vector2(startPos.x + Random.Range(-maxIdleRange, maxIdleRange), startPos.y + Random.Range(-maxIdleRange, maxIdleRange));
        rest = false;
        dirIdle = newPos - (Vector2)transform.position;
        dirIdle.Normalize();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dirIdle, Vector2.Distance(transform.position, newPos), LayerMask.GetMask("Wall"));//check if would hit wall
        if (hit) StartCoroutine("GetIdleNewPos", 0f);
    }

    public void Chasing()
    {
        dir = player.transform.position - transform.position;
        dir.Normalize();
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, chaseSpeed * Time.deltaTime);
        
        if(Vector2.Distance(walkPath[walkPath.Count - 1], transform.position) > 2)
        {
            walkPath.Add(transform.position);
        }
    }

    public void Attacking()
    {

    }

    public void Hit()
    {

    }
}
