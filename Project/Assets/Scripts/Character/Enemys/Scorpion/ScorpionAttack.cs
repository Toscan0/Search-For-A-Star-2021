using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class ScorpionAttack : MonoBehaviour
{
    [SerializeField]
    private float attackRate = 2f;
    public float AttackRate { get { return attackRate; } }
    [SerializeField]
    private int attackDamage = 5;
    [Tooltip("The time it will take to hit the target")]
    [SerializeField]
    private float hintDuration = 1f;
    [SerializeField]
    private Transform target;
    [Tooltip("To tell the player where is going to hit")]
    [SerializeField]
    private GameObject hintCircle;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void StartAttack()
    {
        animator.SetTrigger("Attack");
        DrawCircle();
    }

    private void DrawCircle()
    {
        Vector3 pos = target.position;
        pos.y = 0.1f; //sligtly above the ground

        Instantiate(hintCircle, target.position, Quaternion.Euler(90, 0, 0));
        Invoke("Attack", hintDuration);
    }

    private void Attack()
    {

    }
}
