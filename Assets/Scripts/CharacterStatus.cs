using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public float health;
    public float stamina;
    [SerializeField]private int healthRegeneration;
    [SerializeField]private int staminaRegeneration;
    public int goldAmount;
    void Update()
    {
        if(health<100)
        {
            health += (healthRegeneration * Time.deltaTime);
        }
        if(stamina<100)
        {
            stamina += (staminaRegeneration * Time.deltaTime);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Gold")
        {
            GameObject gold = collision.gameObject;
            goldAmount += 25;
            Destroy(gold);
        }
    }
}
