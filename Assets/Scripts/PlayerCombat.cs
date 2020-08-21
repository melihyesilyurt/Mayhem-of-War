﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private string isAttacking = "Isattacking";
    private string isWaiting = "Iswaiting";
    private Rigidbody2D rigibody;
    private CharacterStatus status;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    private Animator animator;
    [SerializeField] private int damage;
    private EnemyStatus enemyStatus;
    [SerializeField] private GameObject enemy;
    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        status = GetComponent<CharacterStatus>();
        enemyStatus = enemy.GetComponent<EnemyStatus>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            animator.SetTrigger(isWaiting);
        }
    }
    public void Attack()
    {
        if (status.stamina > 20)
        {
            animator.SetTrigger(isAttacking);
            status.stamina = status.stamina - 20;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            int random = UnityEngine.Random.Range(0, 10);
            if (random<3)
            {
                Debug.Log("Miss "+random);
            }
                else
                    {
                foreach (Collider2D enemy in hitEnemies)
                {
                    Debug.Log("we hit " + enemy.name);
                    enemyStatus.health -= damage;
                }
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}