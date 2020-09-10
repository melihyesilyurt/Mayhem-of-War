using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public float health;
    public float stamina;
    [SerializeField] private int healthRegeneration;
    [SerializeField] private int staminaRegeneration;
    private GameObject gold;
    private Transform position;
    private int spawnGold=0;
    private Enemy enemy;
    private float healthFull;
    private float staminaFull;
    private void Start()
    {
        gold = LevelController.Instance.goldCoin;
        position = GetComponent<Transform>();
        enemy = GetComponent<Enemy>();
        healthFull = health;
        staminaFull = stamina;
    }
    void Update()
    {
        if (health < healthFull)
        {
            health += (healthRegeneration * Time.deltaTime);
        }
        if (stamina < staminaFull)
        {
            stamina += (staminaRegeneration * Time.deltaTime);
        }
        if (health <= 0)
        {
            spawnGold++;
            health = -1000;
        }
        if(spawnGold==1)
        {
            enemy.PlayEnemyDeath();
            ScoreController.Instance.ScorePoint += 25;
            gold.transform.localPosition = position.position;
            Instantiate(gold);
        }
    }
}
