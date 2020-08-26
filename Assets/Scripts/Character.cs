﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject character;
    private Rigidbody2D rigibody;
    private CapsuleCollider2D footCollider;
    public float horizontal = 0;
    public bool oneTimeJump = true;
    private Animator animator;
    private string isWalking = "Iswalking";
    private string isJumping = "Isjumping";
    private string isDead = "IsDead";
    private CharacterStatus characterStatus;
    private float deadTime;
    bool oneTimeDead = true;
    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        characterStatus = GetComponent<CharacterStatus>();
        footCollider = GetComponent<CapsuleCollider2D>();
    }
    void Update()
    {
        if (characterStatus.health>0) {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (oneTimeJump)
                {
                    rigibody.AddForce(new Vector2(0, 300));
                    oneTimeJump = false;
                }
            }
        }
    }
    void FixedUpdate()
    {
        if (characterStatus.health > 0)
        {
            CharacterMove();
            Animation();
        }
        else
        {
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
            }
        }
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
        if(collision.otherCollider.GetType()==footCollider.GetType())
        {
            oneTimeJump = true;
        }
    }
}
