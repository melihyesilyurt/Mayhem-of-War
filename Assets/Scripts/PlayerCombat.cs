using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private string isAttacking = "Isattacking";
    private string isWaiting = "Iswaiting";
    public LayerMask enemyLayers;
    private CharacterStatus status;
    public Transform attackPoint;
    public float attackRange;
    private Animator animator;
    [SerializeField] private int damage;
    [SerializeField] private int missPossiblity;
    [SerializeField] private int CriticalPossiblity;
    [SerializeField] private int spendedStamina;
    [SerializeField] private int knockback;
    void Start()
    {
        animator = GetComponent<Animator>();
        status = GetComponent<CharacterStatus>();
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
        if (status.stamina > spendedStamina)
        {
            animator.SetTrigger(isAttacking);
            status.stamina = status.stamina - spendedStamina;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            int random = UnityEngine.Random.Range(0, 100);
            if (random < missPossiblity)
            {
                Debug.Log("Miss " + random);
            }
            else
            {
                random = UnityEngine.Random.Range(0, 100);
                int currentDamage = damage;
                if (random < CriticalPossiblity)
                {
                    currentDamage = damage * 2;
                }
                    foreach (Collider2D enemy in hitEnemies)
                {
                    EnemyCombat enemyCombat = enemy.GetComponent<EnemyCombat>();
                    enemyCombat.TakeDamage(currentDamage,knockback,transform);
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
    public void TakeDamage(int damage)
    {
        status.health -= damage;
    }
}
