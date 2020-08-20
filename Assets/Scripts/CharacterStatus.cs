using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public float health;
    public float stamina;
    void Start()
    {
        health = 100;
        stamina = 100;
    }

    void Update()
    {
        if(health<100)
        {
            health += (1 * Time.deltaTime);
        }
        if(stamina<100)
        {
            stamina += (5 * Time.deltaTime);
        }
              
    }
}
