using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CactusMovement))]
[RequireComponent(typeof(CactusAttack))]
[RequireComponent(typeof(Collider))]
public class CactusController : MonoBehaviour
{
    [Tooltip("How many time the enemy is enabled")]
    [SerializeField]
    private float showTime = 7f;
    [Tooltip("How many time the enemy is disabled")]
    [SerializeField]
    private float hideTime = 3f;
    [SerializeField]
    private GameObject mesh;


    private float showTimer;
    private float hideTimer;
    private float attackTimer;
    private bool show = true; //If the object is enable or not

    private CactusMovement cactusMovement;
    private CactusAttack cactusAttack;
    private NavMeshAgent navMeshAgent;
    private new Collider collider;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        cactusMovement = GetComponent<CactusMovement>();
        cactusAttack = GetComponent<CactusAttack>();

        collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (show)
        {
            showTimer += Time.deltaTime;

            attackTimer += Time.deltaTime;
            if (attackTimer >= cactusAttack.AttackRate)
            {
                attackTimer = 0;

                cactusAttack.StartAttack();
                Debug.Log("Attack");
            }
        }

        if (showTimer >= showTime)
        {
            //Hide
            show = false;
            ShowOrHide(show);
            Debug.Log("Hide");
            //Move too a new pos
            cactusMovement.Move();

            hideTimer += Time.deltaTime;
            if (hideTimer >= hideTime)
            {
                show = true;
                showTimer = 0;
                hideTimer = 0;

                ShowOrHide(show);
                Debug.Log("Show");
            }
        }
    }

    public void ShowOrHide(bool show)
    {
        mesh.SetActive(show);
        collider.enabled = show;
    }
}
