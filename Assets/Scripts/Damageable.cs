using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(DamageInfo damageInfo)
    {
        currentHealth -= damageInfo.damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Add death animation or effects here
        gameObject.SetActive(false);
    }
}

public struct DamageInfo
{
    public float damage;
    public BaseWeapon weapon;
    public float distance;
}