using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SkeletonAttack))]
[RequireComponent(typeof(SkeletonManager))]
public class SkeletonMovement : MonoBehaviour
{
    private Transform target;

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private SkeletonAttack skeletonAttack;
    private SkeletonManager skeletonManager;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        skeletonAttack = GetComponent<SkeletonAttack>();
        skeletonManager = GetComponent<SkeletonManager>();

        target = skeletonManager.Target.transform;
    }

    private void Update()
    {
        if(target != null)
        {
            float dist = Vector3.Distance(target.position, transform.position);

            navMeshAgent.SetDestination(target.position);

            animator.SetBool("IsMoving", true);
            animator.SetBool("Attack", false);

            if (dist <= navMeshAgent.stoppingDistance)
            {
                FaceTarget();

                skeletonAttack.StartAttack();
            }
        }
        
    }

    private void FaceTarget()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
