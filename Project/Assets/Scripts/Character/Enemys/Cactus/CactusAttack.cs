using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class CactusAttack : MonoBehaviour
{
    [SerializeField]
    private float attackRate = 2f;
    public float AttackRate { get { return attackRate; } }
    [SerializeField]
    private int attackDamage = 5;
    [SerializeField]
    private int spikeSpeed = 5;
    [SerializeField]
    private GameObject spikePrefab;

    public Transform[] throwPoints;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void StartAttack()
    {
        animator.SetTrigger("Attack");

        ThrowSpikes();
    }

    private void ThrowSpikes()
    {
        foreach(var throwPoint in throwPoints){
            ThrowSpike(throwPoint.position, throwPoint.rotation);
        }
       
    }

    private void ThrowSpike(Vector3 pos, Quaternion rot)
    {
        var spike = Instantiate(spikePrefab, pos, rot);

        var spikeScript = spike.GetComponent<Spike>();
        spikeScript.Speed = spikeSpeed;
        spikeScript.Damage = attackDamage;
    }

}
