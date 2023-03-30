using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllHealth : MonoBehaviour
{
    public float maxHealth = 100;
    float currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //if(CompareTag("Enemy"))
            
    }
}
