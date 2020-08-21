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
    private string isDead = "IsDead";
    private CharacterStatus characterStatus;
    private float deadTime;
    bool oneTimeDead = true;
    //CharacterStatus status = CharacterStatus CharacterStatus();

    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        characterStatus = GetComponent<CharacterStatus>();
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
            //rigibody.gravityScale = 0;
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
