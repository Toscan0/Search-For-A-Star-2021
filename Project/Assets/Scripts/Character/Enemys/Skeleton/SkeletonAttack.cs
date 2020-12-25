using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkeletonManager))]
[RequireComponent(typeof(Animator))]
public class SkeletonAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject sward;

    private SkeletonManager skeletonManager;
    private Animator animator;

    private void Awake()
    {
        skeletonManager = GetComponent<SkeletonManager>();
        animator = GetComponent<Animator>();
    }

    public void StartAttack()
    {
        animator.SetBool("IsMoving", false);
        animator.SetBool("Attack", true);
    }

    private void Attack()
    {
        sward.SetActive(true);
    }

    private void StopAttack()
    {
        sward.SetActive(false);
    }
}
