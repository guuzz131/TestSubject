using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttack : MonoBehaviour
{
    

    [Header("Type of weapon/bullet")]
    public UnityEvent allAttackEvents;

    [Header("Weapon Stats")]
    [SerializeField] private float AttackCooldown;

    private EnemyStates enemyStates;
    private GameObject player;
    private Transform scene;
    bool isAttacking;

    private void Start()
    {
        enemyStates = transform.parent.GetComponent<EnemyStates>();
        scene = GameObject.FindGameObjectWithTag("Scene").transform;
        player = enemyStates.player;
    }
    public void Attacking()
    {
        if (!isAttacking)
        {
            enemyStates.state = EnemyStates.State.Attacking;
            GetComponent<Animator>().SetTrigger("TriggerAttack");
            //GetComponent<Animator>().Play("EnemyAttackTest");
            StartCoroutine("AttackTimer");
            isAttacking = true;
        }
        
    }
    public void AttackAnimationEvent()
    {
        allAttackEvents.Invoke();
        enemyStates.state = EnemyStates.State.Chasing;
    }
    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(AttackCooldown);
        isAttacking = false;
        
    }
}
