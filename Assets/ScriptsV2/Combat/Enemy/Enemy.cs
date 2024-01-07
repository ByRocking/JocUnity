using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public int damageMob = 30;
    public int valueMob = 14;

    public HealthBarMob healthBar;
    public GameObject deathEffect;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth((float)currentHealth/maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.9f);
        Destroy(gameObject);
        Score.instance.IncreaseScore(valueMob);
    }
}
