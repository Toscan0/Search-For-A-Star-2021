using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(ScorpionMovement))]
[RequireComponent(typeof(ScorpionAttack))]
public class ScorpionController : MonoBehaviour
{
    private float moveTimer;
    private float attackTimer;

    private ScorpionMovement scorpionMovement;
    private ScorpionAttack scorpionAttack;
    private NavMeshAgent navMeshAgent;    

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        scorpionMovement = GetComponent<ScorpionMovement>();
        scorpionAttack = GetComponent<ScorpionAttack>();
    }

    private void Update()
    {
        moveTimer += Time.deltaTime;
        if (moveTimer >= scorpionMovement.MoveTime)
        {
            moveTimer = 0;

            scorpionMovement.Move();
        }

        attackTimer += Time.deltaTime;
        if (attackTimer >= scorpionAttack.AttackRate)
        {
            attackTimer = 0;

            scorpionAttack.StartAttack();
        }
    }
}
