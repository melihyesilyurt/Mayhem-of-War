using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private string isAttacking = "Isattacking";
    private string isWaiting = "Iswaiting";
    private string isDamaged = "IsDamaged";
    private Rigidbody2D enemyrigidbody;
    private CharacterStatus status;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    private Animator animator;
    private Animator enemyAnimator;
    [SerializeField] private int damage;
    private EnemyStatus enemyStatus;
    [SerializeField] private GameObject enemy;
    [SerializeField] private int missPossiblity;
    [SerializeField] private int CriticalPossiblity;
    [SerializeField] private int spendedStamina;
    [SerializeField] private int knockback;
    void Start()
    {
        enemyrigidbody = enemy.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        status = GetComponent<CharacterStatus>();
        enemyStatus = enemy.GetComponent<EnemyStatus>();
        enemyAnimator = enemy.GetComponent<Animator>();
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
                    foreach (Collider2D enemy in hitEnemies)
                    {
                        random = UnityEngine.Random.Range(0, 100);
                        if (random < CriticalPossiblity)
                        {
                            Debug.Log("critical " + random);
                            enemyStatus.health -= 2 * damage;
                        }
                        else
                        {
                            Debug.Log("we hit " + enemy.name);
                            enemyStatus.health -= damage;
                        enemyAnimator.SetTrigger(isDamaged);
                        }
                        if (enemy.transform.position.x > transform.position.x)
                        {
                            enemyrigidbody.AddForce(new Vector2(knockback, 0));
                        }
                        if (enemy.transform.position.x < transform.position.x)
                        {
                            enemyrigidbody.AddForce(new Vector2(-knockback, 0));
                        }
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
