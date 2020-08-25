using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float speed, distance;
    private bool walk, attack;
   [SerializeField] private Transform character;
    private Rigidbody2D rigibody;
    private Animator animator;
    private string isWaiting = "Iswaiting";
    private string isAttacking = "Isattacking";
    private string isWalking = "Iswalking";
    private string isJumping = "Isjumping";
    private string isDead = "IsDead";
    private string isDamaged = "IsDamaged";
    private bool oneTimeJump = true;
    private EnemyCombat enemyCombat;
    private EnemyStatus enemystatus;
    bool oneTimeDead = true;
    private float deadTime;
    [SerializeField] private float attackSpeed;
    private float timeAttack;
    // private Collider2D collider;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigibody = GetComponent<Rigidbody2D>();
        enemyCombat = GetComponent<EnemyCombat>();
        enemystatus = GetComponent<EnemyStatus>();
        //timeAttack = attackSpeed;
       // collider = GetComponent<>();
    }
    void Update()
    {
        distance = Vector3.Distance(transform.position, character.position);
            if (distance < 5 && distance > 0.3f)
            {
                walk = true;
                attack = false;
                //Debug.Log("yürüyor");
            }
            if (distance < 0.3f)
            {

                walk = false;
                attack = true;
                //Debug.Log("ateş ediyor");
            }
            if (distance > 5)
            {
                walk = false;
                attack = false;
                //Debug.Log("bekliyor");
            }
        if (enemystatus.health > 0)
        {
            if (walk)
            {
                Movement();
                speed = 1;
                transform.position = Vector3.MoveTowards(transform.position, character.position, speed * Time.deltaTime);
            }
            if (attack)
            {
                timeAttack += (1 * Time.deltaTime);
                if (attackSpeed < timeAttack)
                {
                    enemyCombat.Attack();
                    timeAttack = 0;
                }
                animator.SetBool(isWalking, false);
                animator.SetTrigger(isWaiting);

            }
            if (walk == false && attack == false)
            {
                animator.SetBool(isWalking, false);
                animator.SetBool(isJumping, false);
            }
        }
        else
        {
            walk = false;
            attack = false;
            animator.SetBool(isWalking, false);
            animator.SetBool(isJumping, false);
            //animator.SetTrigger(isWaiting);
           
            if(oneTimeDead)
            {
               animator.SetTrigger(isDead);
                oneTimeDead = false;
            }
          rigibody.constraints = RigidbodyConstraints2D.FreezePosition;
            GetComponent<CapsuleCollider2D>().isTrigger= true;
           GetComponent<PolygonCollider2D>().isTrigger = true;
            deadTime += (1 * Time.deltaTime);
            if (1.75f<deadTime)
            {
                Destroy(gameObject);
            }
        }
    }
    public void Movement()
    {
        if (oneTimeJump)
        {
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
                animator.SetBool(isWalking, true);
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
                animator.SetBool(isWalking, true);
            }
            if (character.transform.position.y > transform.localPosition.y)
            {
                rigibody.AddForce(new Vector2(0, 300));
                oneTimeJump = false;
                animator.SetBool(isJumping, true);
            }
            else
            {
                animator.SetBool(isJumping, false);
            }
        }  
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool(isJumping, false);
        oneTimeJump = true;
    }
    }
