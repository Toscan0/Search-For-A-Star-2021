using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(ZombieAttack))]
public class ZombieMovement : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private ZombieAttack zombieAttack;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        zombieAttack = GetComponent<ZombieAttack>();
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
                animator.SetBool("IsMoving", false);
                animator.SetBool("Attack", true);

                FaceTarget();

                zombieAttack.Attack(target.gameObject);
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
