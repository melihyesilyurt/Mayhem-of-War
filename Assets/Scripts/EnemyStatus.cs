﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public float health;
    public float stamina;
    [SerializeField] private int healthRegeneration;
    [SerializeField] private int staminaRegeneration;
    [SerializeField]private GameObject Gold;
    private Animator animator;
    private Transform position;
    
    private int spawnGold=0;

    private void Start()
    {
        position = GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (health < 100)
        {
            health += (healthRegeneration * Time.deltaTime);
        }
        if (stamina < 100)
        {
            stamina += (staminaRegeneration * Time.deltaTime);
        }
        if (health <= 0)
        {
            spawnGold++;
        }
        if(spawnGold==1)
        {
            Gold.transform.localPosition = position.position;
            Instantiate(Gold);
        }
    }
}
