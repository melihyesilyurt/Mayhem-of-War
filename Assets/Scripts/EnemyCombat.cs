using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    private string isAttacking = "Isattacking";
    private string isDamaged = "IsDamaged";
    private EnemyStatus status;
    private Rigidbody2D rigibody;
    [SerializeField] private int possibility;
    public Transform attackPoint;
    public float attackRange;
    [SerializeField] private int damage;
    public LayerMask enemyLayers;
    [SerializeField] private int spendedStamina;
    [SerializeField] private int CriticalPossiblity;
    [SerializeField] private float attackSpeed;
    private float timeAttack;
    private Animator animator;
    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        status = GetComponent<EnemyStatus>();
    }
    public void Attack()
    {
        if (status.stamina > spendedStamina)
        {
            animator.SetTrigger(isAttacking);
            status.stamina = status.stamina - spendedStamina;
            Collider2D[] hitCharacter = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            int random = UnityEngine.Random.Range(0, 100);
            if (random < possibility)
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
                foreach (Collider2D character in hitCharacter)
                {
                    PlayerCombat playerCombat = character.GetComponent<PlayerCombat>();
                    Debug.Log(currentDamage);
                    playerCombat.TakeDamage(currentDamage);
                    break;
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
    public void TakeDamage(int damage, int knockback, Transform character)
    {
        status.health -=  damage;
        animator.SetTrigger(isDamaged);
        if (transform.position.x > character.position.x)
        { 
            rigibody.AddForce(new Vector2(knockback, 0));
        }
        if (transform.position.x < character.position.x)
        {
            rigibody.AddForce(new Vector2(-knockback, 0));
        }
    }
}
