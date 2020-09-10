using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public float health;
    public float stamina;
    private float healthFull;
    private float staminaFull;
    [SerializeField]private int healthRegeneration;
    [SerializeField]private int staminaRegeneration;
    public int goldAmount;

    private void Start()
    {
        healthFull = health;
        staminaFull = stamina;
    }
    void Update()
    {
        if(health< healthFull)
        {
            health += (healthRegeneration * Time.deltaTime);
        }
        if(stamina< staminaFull)
        {
            stamina += (staminaRegeneration * Time.deltaTime);
        }
        GameInterFace.Instance.healthBar.fillAmount = health/healthFull;
        GameInterFace.Instance.staminaBar.fillAmount = stamina/staminaFull;
        GoldController.Instance.SetGoldText(goldAmount);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Gold")
        {
            MusicManager.Instance.PlayTakeGoldClip();
            GameObject gold = collision.gameObject;
            goldAmount += 25;
            Destroy(gold);
        }
    }
}
