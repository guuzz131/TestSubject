using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyStates : MonoBehaviour
{
    [Header("References")]
    public GameObject player;
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private EnemyAttack enemyAttack;
    [SerializeField] private Animator animator;

    [Header("State Machine")]
    public State state;

    [Header("Detection Radiuses")]
    [SerializeField] private float spotDistance;
    [SerializeField] private float attackDistance;

    [Header("Miscilanius")]
    [SerializeField] private bool showGizmos;

    private float biggestRadius;
    private float smallestRadius;
    bool isSpotBigger;

    public enum State
    {
        Idle,
        Chasing,
        Attacking,
        Hit,
    }
    void Start()
    {
        player = GameObject.Find("Player");
        state = State.Idle;
        if (spotDistance > attackDistance)
        {
            biggestRadius = spotDistance;
            smallestRadius = attackDistance;
            isSpotBigger = true;
        }
        else
        {
            biggestRadius = attackDistance;
            smallestRadius = spotDistance;
            isSpotBigger = false;
        }
    }

    void Update()
    {
        
        switch (state)
        {
            default:
            case State.Idle:
                enemyMovement.Idle();
                break;
            case State.Chasing:
                enemyMovement.Chasing();
                break;
            case State.Attacking:
                enemyAttack.Attacking();
                enemyMovement.Attacking();
                break;
            case State.Hit:
                enemyMovement.Hit();
                break;
        }
        if (state == State.Hit)
            return;
        StateCheck();
    }

    private void StateCheck()
    {
        Collider2D coll = Physics2D.OverlapCircle(transform.position, biggestRadius, LayerMask.GetMask("Player")); //circle collide with player?
        if (!coll)
        {
            state = State.Idle;
            return; //if not go bak
        }

        Vector2 endPos = coll.transform.position;
        Vector2 dir = (endPos - (Vector2)transform.position);
        float dist = Vector2.Distance(transform.position, endPos);
        Debug.DrawRay(transform.position, dir.normalized);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir.normalized, dist, LayerMask.GetMask("Wall")); //if there is a wall inbetween, break contact
        if (hit)
        {
            state = State.Idle;
            return; //if not go bak
        }

        if (Vector2.Distance(transform.position, coll.transform.position) <= smallestRadius) //check if should attack
        {
            if (isSpotBigger) state = State.Attacking;
            else state = State.Chasing;
            return;
        }


        if (isSpotBigger) state = State.Chasing;
        else state = State.Attacking;
        
    }

    
    private void OnDrawGizmos() //gets called when gizmos are enabled (edittor only)
    {
        if (!showGizmos) return;
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, transform.forward, attackDistance);

        Handles.color = Color.white;
        Handles.DrawWireDisc(transform.position, transform.forward, spotDistance);
    }
}
