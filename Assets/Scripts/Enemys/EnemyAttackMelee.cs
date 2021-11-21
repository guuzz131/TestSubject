using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyAttackMelee : MonoBehaviour
{
    [SerializeField] private float meleeRange;
    [SerializeField] private float meleeRadius;

    private Vector2 attackPos;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    public void DoAttack()
    {
        Vector2 dir = gameManager.player.transform.position - transform.position;
        attackPos = (Vector2)transform.position + dir * meleeRange;
        Collider2D attackCol = Physics2D.OverlapCircle(attackPos, meleeRadius, LayerMask.GetMask("Player"));
        if (!attackCol)
        {
            Debug.Log("Missed");
            return;
        }
        Debug.Log("Hit by melee");

        
    }

    private void OnDrawGizmos() //gets called when gizmos are enabled (edittor only)
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(attackPos, transform.forward, meleeRadius);
    }
    
}
