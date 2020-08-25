using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    private string isAttacking = "Isattacking";
    private string isWaiting = "Iswaiting";
    private EnemyStatus status;
    [SerializeField] private int possibility;
    public Transform attackPoint;
    public float attackRange;
    [SerializeField]private int damage;
    public LayerMask enemyLayers;
    private CharacterStatus characterStatus;
    [SerializeField] private GameObject character;
    [SerializeField] private int spendedStamina;
    [SerializeField] private int CriticalPossiblity;

    private Animator animator;
    void Start()
    {
      
        animator = GetComponent<Animator>();
        status = GetComponent<EnemyStatus>();
        characterStatus = character.GetComponent<CharacterStatus>();
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
                    foreach (Collider2D character in hitCharacter)
                    {
                    random = UnityEngine.Random.Range(0, 100);
                    if (random < CriticalPossiblity)
                    {
                        Debug.Log("critical " + random);
                        characterStatus.health -= 2 * damage;
                    }
                    else
                    {
                        Debug.Log("He hit " + character.name);
                        characterStatus.health -= damage;
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
