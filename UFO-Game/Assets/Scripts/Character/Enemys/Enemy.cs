﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    // how much gold is deployed when killed
    [SerializeField]
    protected int gold;
    // how much XP is deployed when killed
    [SerializeField]
    protected float XP;
    // true if it is a boss
    [SerializeField]
    protected bool boss;
    // true if this enemy throws a heart when die
    [SerializeField]
    protected bool throwsHeart;
    [SerializeField]
    protected GameObject heartPrefab;
    [SerializeField]
    protected GameObject goldPrefab;

    public static Action OnEnemySpawn;
    public static Action OnEnemyDeath;

    private new void Start()
    {
        base.Start();

        // Tell the enemys manager that one enemy was spawn
        OnEnemySpawn?.Invoke();

        PlayerManager.OnPlayerDeath += EnemysWin;
    }

    protected void ThrowHeart()
    {
        if (throwsHeart)
        {
            Instantiate(heartPrefab, transform.position, Quaternion.identity);
        }
    }

    protected void ThrowGold(Vector3 pos)
    {
        // At the moment 1 gold = 1 obj
        for(int i = 0; i < gold; i++)
        {
            Instantiate(goldPrefab, goldPrefab.transform.position + pos, Quaternion.identity);
        }
    }

    public void CollisionWithPlayer(GameObject go)
    {
        if (go.CompareTag("Player"))
        {
            var damagable = go.GetComponent<IDamagable>();
            damagable.TakeDamage(collisionDamage);
        }
    }

    protected void Die()
    {
        gameObject.GetComponent<Collider>().enabled = false;

        OnEnemyDeath?.Invoke();
    }

    //When the player lost
    private void EnemysWin()
    {
        var enemy = gameObject.GetComponent<IVictoryAnim>();
        if(enemy != null)
        {
            enemy.PlayVictoryAnim();
        }
    }

    private void OnDestroy()
    {
        PlayerManager.OnPlayerDeath -= EnemysWin;
    }
}
