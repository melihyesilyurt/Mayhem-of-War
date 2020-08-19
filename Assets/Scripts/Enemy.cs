using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject character;
    public Rigidbody2D rigibody;
    public float horizontal = 0;
    public bool oneTimeJump = true;
    public Animator animator;
    private string isWaiting = "Iswaiting";
    private string isAttacking = "Isattacking";
    private string isWalking = "Iswalking";
    private string isJumping = "Isjumping";

    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (oneTimeJump)
            {
                rigibody.AddForce(new Vector2(0, 300));
                oneTimeJump = false;
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            animator.SetTrigger(isWaiting);
        }
    }
    void FixedUpdate()
    {
        CharacterMove();
        Animation();
    }
    public void Attack()
    {
        animator.SetTrigger(isAttacking);
    }
    public void CharacterMove()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        rigibody.velocity = new Vector3(horizontal * 3, rigibody.velocity.y, 0);
    }
    public void Animation()
    {
        if (oneTimeJump)
        {
            if (horizontal == 0)
            {
                animator.SetBool(isWalking, false);
                animator.SetBool(isJumping, false);
            }
            else if (horizontal > 0)
            {

                if (character.transform.localScale.x < 0)
                {
                    character.transform.localScale = new Vector3(-1 * character.transform.localScale.x, character.transform.localScale.y, 1);
                }
                else
                {
                    character.transform.localScale = new Vector3(character.transform.localScale.x, character.transform.localScale.y, 1);
                }
                animator.SetBool(isWalking, true);
            }
            else if (horizontal < 0)
            {

                if (character.transform.localScale.x < 0)
                {
                    character.transform.localScale = new Vector3(character.transform.localScale.x, character.transform.localScale.y, 1);
                }
                else
                {
                    character.transform.localScale = new Vector3(-1 * character.transform.localScale.x, character.transform.localScale.y, 1);
                }
                animator.SetBool(isWalking, true);
            }
        }
        else
        {
            if (rigibody.velocity.y > 0)
            {
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
