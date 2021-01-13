﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ZombieManager : Enemy
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        GetComponent<Collider>().enabled = true;
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //animator.SetTrigger("Hit");

        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    private new IEnumerator Die()
    {
        base.Die();

        animator.SetTrigger("Die");

        ThrowHeart(transform.position);
      
        yield return new WaitForSeconds(1.10f);

        ThrowGold(transform.position);
        Destroy(gameObject);
    }
}
