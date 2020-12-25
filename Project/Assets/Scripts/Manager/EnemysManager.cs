using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemysManager : MonoBehaviour
{
    private int enemysCount = 0;

    public static Action OnPlayerWin;

    void Awake()
    {
        Enemy.OnEnemyDeath += DecEnemysAlive;
        Enemy.OnEnemySpawn += IncrEnemysAlive;
        
    }

    private void IncrEnemysAlive()
    {
        enemysCount++;
    }

    private void DecEnemysAlive()
    {
        enemysCount--;

        // Player win the level
        if(enemysCount <= 0)
        {
            OnPlayerWin?.Invoke();
        }
    }

    void OnDisable()
    {
        Enemy.OnEnemySpawn -= IncrEnemysAlive;
        Enemy.OnEnemyDeath -= DecEnemysAlive;
    }
}
