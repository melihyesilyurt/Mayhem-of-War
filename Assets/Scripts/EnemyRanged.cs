using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyRanged : MonoBehaviour
{
    private string isAttacking = "Isattacking";
    private string isDamaged = "IsDamaged";
    private EnemyStatus status;
    private Rigidbody2D rigibody;
    public float attackRange;
    [SerializeField] private int damage;
    [SerializeField] private int spendedStamina;
    [SerializeField] private int CriticalPossiblity;
    private Animator animator;
    [SerializeField] private GameObject arrow;
    private Transform character;
    public float launchForce;
    private int numberArrows = 0;
    private GameObject[] Arrows;
    private double xAxis;
    private double yAxis;
    private double degree;
    void Start()
    {
        character = LevelController.Instance.character;
        rigibody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        status = GetComponent<EnemyStatus>();
        Arrows = new GameObject[3];
    }
    public void Attack()
    {
        if (status.stamina > spendedStamina)
        {
            animator.SetTrigger(isAttacking);
            status.stamina = status.stamina - spendedStamina;
            GameObject newArrow = Instantiate(arrow, transform.position, character.rotation);
            Arrow arrowBehaviour = newArrow.GetComponent<Arrow>();
            arrowBehaviour.owner = this;
            Vector3 temp = new Vector3(0, -0.07619f, 0);
            newArrow.transform.position += temp;
            xAxis = character.position.x - newArrow.transform.position.x;
            yAxis = character.position.y - newArrow.transform.position.y;
            double result = yAxis / xAxis;
            degree = Math.Atan(result);
            degree = degree * (180 / Math.PI);
            newArrow.transform.Rotate(0f, 0f, (float)degree, Space.Self);
            Vector2 directionVector = new Vector2((float)xAxis, (float)yAxis);
            Arrows[numberArrows] = newArrow;
            numberArrows++;
            newArrow.GetComponent<Rigidbody2D>().AddForce(launchForce * directionVector.normalized);
            if (character.transform.position.x > transform.localPosition.x)
            {
                if (transform.localScale.x < 0)
                {
                    transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, 1);
                }
                else
                {
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1);
                }
                newArrow.transform.Rotate(0f, 0f, 180, Space.Self);
            }
            else if (character.transform.position.x < transform.localPosition.x)
            {
                if (transform.localScale.x < 0)
                {
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1);
                }
                else
                {
                    transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, 1);
                }
            }
            if (numberArrows > 2)
            {
                Destroy(Arrows[0]);
                Arrows[0] = Arrows[1];
                Arrows[1] = Arrows[2];
                numberArrows--;
            }
        }
    }
    public void TakeDamage(int damage, int knockback, Transform character)
    {
        status.health -= damage;
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
    public void OnArrowHit()
    {
        int random = UnityEngine.Random.Range(0, 100);
        int currentDamage = damage;
        if (random < CriticalPossiblity)
        {
            currentDamage = damage * 2;
        }
        PlayerCombat playerCombat = character.GetComponent<PlayerCombat>();
        playerCombat.TakeDamage(currentDamage);
    }
}
