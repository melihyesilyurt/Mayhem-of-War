using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed, distance;
    private bool walk, attack;
    private Transform character;
    private Rigidbody2D rigibody;
    private Animator animator;
    private string isWaiting = "Iswaiting";
    private string isWalking = "Iswalking";
    private string isJumping = "Isjumping";
    private string isDead = "IsDead";
    private bool oneTimeJump = true;
    private EnemyCombat enemyCombat;
    private EnemyRanged enemyRanged;
    private EnemyStatus enemystatus;
    bool oneTimeDead = true;
    private float deadTime;
    [SerializeField] private float attackDistance;
    [SerializeField] private float walkDistance;
    [SerializeField] private float attackSpeed;
    private float timeAttack;
    private float timeJump;
    [SerializeField] private int jumpPower;
    [SerializeField] private AudioClip enemyAttackClip;
    [SerializeField] private AudioClip enemyDeathClip;
    private AudioSource audioSource;
    void Start()
    {
        character = LevelController.Instance.character;
        animator = GetComponent<Animator>();
        rigibody = GetComponent<Rigidbody2D>();
        enemyCombat = GetComponent<EnemyCombat>();
        enemystatus = GetComponent<EnemyStatus>();
        enemyRanged = GetComponent<EnemyRanged>();
        audioSource = GetComponent<AudioSource>();
        timeAttack = attackSpeed + 1;
        timeJump = 1;
    }
    void Update()
    {
        distance = Vector3.Distance(transform.position, character.position);
        if (distance < walkDistance && distance > attackDistance)
        {
            walk = true;
            attack = false;
            //Debug.Log("yürüyor");
        }
        if (distance < attackDistance)
        {

            walk = false;
            attack = true;
            //Debug.Log("ateş ediyor");
        }
        if (distance > walkDistance)
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
                    timeAttack = 0;
                  
                    if (gameObject.tag == "EnemyArcher")
                    {
                        enemyRanged.Attack();
                    }
                    else
                    {
                        enemyCombat.Attack();
                    }      
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
            if (oneTimeDead)
            {
                animator.SetTrigger(isDead);
                oneTimeDead = false;
            }
            rigibody.constraints = RigidbodyConstraints2D.FreezePosition;
            GetComponent<CapsuleCollider2D>().isTrigger = true;
            GetComponent<PolygonCollider2D>().isTrigger = true;
            deadTime += (1 * Time.deltaTime);
            if (1.75f < deadTime)
            {
                Destroy(gameObject);
                ScoreController.Instance.comboCount++;
                ScoreController.Instance.enemyDeathCount++;
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
            timeJump += (1 * Time.deltaTime);
            if (character.transform.position.y > transform.localPosition.y)
            {
                if (timeJump>0.5f)
                {
                    rigibody.AddForce(new Vector2(0, jumpPower));
                    oneTimeJump = false;
                    animator.SetBool(isJumping, true);
                    timeJump = 0;
                }
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
    public void PlayEnemyAttack()
    {
        audioSource.clip = enemyAttackClip;
        PlaySound();
    }
    public void PlayEnemyDeath()
    {
        audioSource.clip = enemyDeathClip;
        PlaySound();
    }
    private void PlaySound()
    {
        if (PlayerPrefs.GetInt("Voice") == 0)
        {
            audioSource.Play();
            // Debug.Log("Musicon");
        }
        else if (PlayerPrefs.GetInt("Voice") == -1)
        {
            audioSource.Stop();
            // Debug.Log("Musicoff");
        }
       // audioSource.Play();
    }
}
