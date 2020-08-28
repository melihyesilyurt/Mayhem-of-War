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

    private void Start()
    {
        gold = LevelController.Instance.goldCoin;
        position = GetComponent<Transform>();
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
            gold.transform.localPosition = position.position;
            Instantiate(gold);
        }
    }
}
