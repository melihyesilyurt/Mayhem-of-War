using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    private string isAttacking = "Isattacking";
    private string isWaiting = "Iswaiting";
    private Rigidbody2D rigibody;
    private EnemyStatus status;
    public Transform attackPoint;
    public float attackRange;
    [SerializeField]private int damage;
    public LayerMask enemyLayers;
    private CharacterStatus characterStatus;
    [SerializeField] private GameObject character;
    private Animator animator;
    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        status = GetComponent<EnemyStatus>();
        characterStatus = character.GetComponent<CharacterStatus>();
    }
    public void Attack()
    {
        if (status.stamina > 20)
        {
            animator.SetTrigger(isAttacking);
            status.stamina = status.stamina - 20;
            Collider2D[] hitCharacter = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            int random = UnityEngine.Random.Range(0, 10);
            if (random < 3)
            {
                Debug.Log("Miss " + random);
            }
            else
            {
                foreach (Collider2D character in hitCharacter)
                {
                    Debug.Log("He hit " + character.name);
                    characterStatus.health -= damage;
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
