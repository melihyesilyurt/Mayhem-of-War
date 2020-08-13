using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters :MonoBehaviour
{
    public Sprite[] idleAnim;
    public Sprite[] jumpAnim;
    public Sprite[] walkAnim;
    public Sprite[] attackAnim;
    public Sprite[] DeathAnim;
    public Sprite[] fallAnim;
    public GameObject character;
    public int idleAnimnumb = 0;
    public int walkAnimnumb = 0;
    public int jumpAnimnumb = 0;
    public int fallAnimnumb = 0;
    public int attackAnimnumb = 0;
    public SpriteRenderer spriteRendere;
    public Rigidbody2D physics;
    public Vector3 vec;
    public float horizontal = 0;
    public float idlewaittime = 0;
    public float walkwaittime = 0;
    public bool OneTimeJump = true;
    public void Attack()
    {

        spriteRendere.sprite = attackAnim[attackAnimnumb++];
        if (attackAnimnumb == attackAnim.Length)
        {
            attackAnimnumb = 0;
        }

    }
    public void charactermove()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vec = new Vector3(horizontal * 3, physics.velocity.y, 0);
        physics.velocity = vec;
    }
    public void Animation()
    {
        if (OneTimeJump)
        {
            if (horizontal == 0)
            {
                idlewaittime += Time.deltaTime;
                if (idlewaittime > 0.1f)
                {
                    spriteRendere.sprite = idleAnim[idleAnimnumb++];
                    if (idleAnimnumb == idleAnim.Length)
                    {
                        idleAnimnumb = 0;
                    }
                    idlewaittime = 0;
                }

            }
            else if (horizontal > 0)
            {

                walkwaittime += Time.deltaTime;
                if (walkwaittime > 0.06f)
                {
                    spriteRendere.sprite = walkAnim[walkAnimnumb++];
                    if (walkAnimnumb == walkAnim.Length)
                    {
                        walkAnimnumb = 0;
                    }
                    walkwaittime = 0;
                }
                character.transform.localScale = new Vector3(1.4f, 1.4f, 1);

            }
            else if (horizontal < 0)
            {
                walkwaittime += Time.deltaTime;
                if (walkwaittime > 0.06f)
                {
                    spriteRendere.sprite = walkAnim[walkAnimnumb++];
                    if (walkAnimnumb == walkAnim.Length)
                    {
                        walkAnimnumb = 0;
                    }
                    walkwaittime = 0;
                }
                character.transform.localScale = new Vector3(-1.4f, 1.4f, 1);

            }

        }
        else
        {
            if (physics.velocity.y > 0)
            {
                walkwaittime += Time.deltaTime;

                spriteRendere.sprite = jumpAnim[jumpAnimnumb++];
                if (jumpAnimnumb == jumpAnim.Length)
                {
                    jumpAnimnumb = 0;
                }

            }
            else
            {
                spriteRendere.sprite = fallAnim[fallAnimnumb++];
                if (fallAnimnumb == fallAnim.Length)
                {
                    fallAnimnumb = 0;
                }
            }
        }
    }
   public void OnCollisionEnter2D(Collision2D collision)
    {
        OneTimeJump = true;
    }
}
