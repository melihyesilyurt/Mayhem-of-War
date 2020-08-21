using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public GameObject character;
    public Rigidbody2D rigibody;
    
    //[SerializeField] private CapsuleCollider2D footCollider;
    //private CapsuleCollider2D footCollider;
    public float horizontal = 0;
    public bool oneTimeJump = true;
    public Animator animator;
    private string isWaiting = "Iswaiting";
    private string isAttacking = "Isattacking";
    private string isWalking = "Iswalking";
    private string isJumping = "Isjumping";
    //CharacterStatus status = CharacterStatus CharacterStatus();

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
       
    }
    void FixedUpdate()
    {
        CharacterMove();
        Animation();
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

        ///  Debug.Log(collision.collider.GetType());
        /*footCollider = GetComponent<CapsuleCollider2D>();

        if (footCollider.IsTouching == true)
        {
            Debug.Log("Melih");
        }
        else
        {
            Debug.Log("Meliheeee");
        }
        /*  Debug.Log(collision.collider.GetType());
          //Debug.Log(footCollider.GetType());
          string footCollider = collision.collider.GetType().ToString.;
          //Debug.Log("eee)");
          //"UnityEngine.BoxCollider2D"
          if (collision.collider.GetType().ToString == "BoxCollider2D" )
      {
          Debug.Log("Melih");
      }
      else
      {
          Debug.Log("Meliheeee");
      }*/
    }
}
