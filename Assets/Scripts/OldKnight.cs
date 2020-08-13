using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldKnight  : Characters
{
    void Start()
    {
        
        spriteRendere = GetComponent<SpriteRenderer>();
        physics = GetComponent<Rigidbody2D>();
         
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (OneTimeJump)
            {
                physics.AddForce(new Vector2(0, 300));
                OneTimeJump = false;
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }
    void FixedUpdate()
    {
        charactermove();
        Animation();
    }
}
