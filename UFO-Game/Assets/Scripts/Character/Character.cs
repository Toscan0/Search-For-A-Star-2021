using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamagable
{
    [SerializeField]
    protected int maxHealth;
    protected int currentHealth;

    [SerializeField]
    protected int collisionDamage;

    protected void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        Debug.Log("TakeDamage from character class");
    }
}
