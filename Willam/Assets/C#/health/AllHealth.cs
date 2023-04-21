using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllHealth : MonoBehaviour
{
    public int maxHealth = 100;
    float currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (CompareTag("Enemy"))
            Destroy(gameObject);
    }

    internal void TakeDamage(object damage)
    {
        throw new NotImplementedException();
    }
}
